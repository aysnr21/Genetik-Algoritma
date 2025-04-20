using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GeneticAlgorithmProject
{
    public partial class Form1 : Form
    {
        private Random _random;

        public Form1()
        {
            InitializeComponent();
            InitializeChart();
            _random = new Random();
        }

        private void InitializeChart()
        {
            chart1.Series.Clear();

            // ChartArea ekleyin
            chart1.ChartAreas.Add(new ChartArea());

            var series = new Series("Fitness");
            series.ChartType = SeriesChartType.Line;
            series.XValueType = ChartValueType.Int32;  // X ekseni için integer değerler
            series.YValueType = ChartValueType.Double;  // Y ekseni için double değerler
            chart1.Series.Add(series);

            // Eksen etiketleri ve başlıklar
            chart1.ChartAreas[0].AxisX.Title = "Jenerasyonlar";
            chart1.ChartAreas[0].AxisY.Title = "Fitness Değeri";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                int populationSize = int.Parse(txtPopulationSize.Text);
                double crossoverRate = double.Parse(txtCrossoverRate.Text);
                double mutationRate = double.Parse(txtMutationRate.Text);
                int elitismCount = int.Parse(txtElitismCount.Text);
                int generations = int.Parse(txtGenerations.Text);

                // Rosenbrock Fonksiyonu
                Func<double[], double> fitnessFunction = (genes) =>
                {
                    double sum = 0;
                    for (int i = 0; i < genes.Length - 1; i++)
                    {
                        sum += 100 * Math.Pow(genes[i + 1] - Math.Pow(genes[i], 2), 2) + Math.Pow(genes[i] - 1, 2);
                    }
                    return sum;
                };

                // Genetik algoritma başlatma
                GeneticAlgorithm ga = new GeneticAlgorithm(populationSize, 2, crossoverRate, mutationRate, elitismCount, fitnessFunction, -5, 5);

                chart1.Series["Fitness"].Points.Clear();
                for (int i = 0; i < generations; i++)
                {
                    ga.Evolve();

                    // Fitness değerini kontrol etmek
                    Console.WriteLine($"Jenerasyon {i}: En iyi Fitness = {ga.GetBestIndividual().Fitness}");

                    chart1.Series["Fitness"].Points.AddXY(i, ga.GetBestIndividual().Fitness);

                    // Label'leri güncelle
                    lblBestSolution.Text = $"En İyi Çözüm: x = {ga.GetBestIndividual().Genes[0]:F4}, y = {ga.GetBestIndividual().Genes[1]:F4}";
                    lblBestFitness.Text = $"En İyi Fitness: {ga.GetBestIndividual().Fitness:F4}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class Individual
    {
        public double[] Genes { get; set; }
        public double Fitness { get; set; }

        public Individual(int geneLength, double minValue, double maxValue, Random random)
        {
            Genes = new double[geneLength];
            for (int i = 0; i < geneLength; i++)
            {
                Genes[i] = random.NextDouble() * (maxValue - minValue) + minValue;
            }
            Fitness = 0;
        }

        public void CalculateFitness(Func<double[], double> fitnessFunction)
        {
            Fitness = fitnessFunction(Genes);
        }
    }

    public class Population
    {
        public List<Individual> Individuals { get; set; }

        public Population(int populationSize, int geneLength, double minValue, double maxValue, Random random)
        {
            Individuals = new List<Individual>();
            for (int i = 0; i < populationSize; i++)
            {
                Individuals.Add(new Individual(geneLength, minValue, maxValue, random));
            }
        }

        public Individual GetFittest()
        {
            return Individuals.OrderBy(i => i.Fitness).First();
        }
    }

    public class GeneticAlgorithm
    {
        private Population _population;
        private double _crossoverRate;
        private double _mutationRate;
        private int _elitismCount;
        private Func<double[], double> _fitnessFunction;
        private double _minValue;
        private double _maxValue;
        private Random _random;

        public GeneticAlgorithm(int populationSize, int geneLength, double crossoverRate, double mutationRate, int elitismCount, Func<double[], double> fitnessFunction, double minValue, double maxValue)
        {
            _random = new Random();
            _population = new Population(populationSize, geneLength, minValue, maxValue, _random);
            _crossoverRate = crossoverRate;
            _mutationRate = mutationRate;
            _elitismCount = elitismCount;
            _fitnessFunction = fitnessFunction;
            _minValue = minValue;
            _maxValue = maxValue;

            // Fitness değerlerini hesapla
            foreach (var individual in _population.Individuals)
            {
                individual.CalculateFitness(_fitnessFunction);
            }
        }

        public void Evolve()
        {
            var newPopulation = new List<Individual>();

            // Elitizm: En iyi bireyleri yeni popülasyona ekle
            var elites = _population.Individuals.OrderBy(i => i.Fitness).Take(_elitismCount).ToList();
            newPopulation.AddRange(elites);

            // Yeni popülasyonu oluştur
            while (newPopulation.Count < _population.Individuals.Count)
            {
                var parent1 = SelectParent();
                var parent2 = SelectParent();

                if (_random.NextDouble() < _crossoverRate)
                {
                    var (child1, child2) = Crossover(parent1, parent2);
                    newPopulation.Add(child1);
                    newPopulation.Add(child2);
                }
                else
                {
                    newPopulation.Add(parent1);
                    newPopulation.Add(parent2);
                }
            }

            // Mutasyon uygula
            foreach (var individual in newPopulation)
            {
                Mutate(individual);
            }

            // Yeni popülasyon ile eski popülasyonu değiştir
            _population.Individuals = newPopulation;

            // Fitness hesaplamayı güncelle
            foreach (var individual in _population.Individuals)
            {
                individual.CalculateFitness(_fitnessFunction);
            }
        }

        private Individual SelectParent()
        {
            var tournamentSize = 5;
            var tournament = _population.Individuals.OrderBy(x => _random.Next()).Take(tournamentSize).ToList();
            return tournament.OrderBy(i => i.Fitness).First();
        }

        private (Individual, Individual) Crossover(Individual parent1, Individual parent2)
        {
            var child1 = new Individual(parent1.Genes.Length, _minValue, _maxValue, _random);
            var child2 = new Individual(parent2.Genes.Length, _minValue, _maxValue, _random);

            for (int i = 0; i < parent1.Genes.Length; i++)
            {
                if (_random.NextDouble() < 0.5)
                {
                    child1.Genes[i] = parent1.Genes[i];
                    child2.Genes[i] = parent2.Genes[i];
                }
                else
                {
                    child1.Genes[i] = parent2.Genes[i];
                    child2.Genes[i] = parent1.Genes[i];
                }
            }

            return (child1, child2);
        }

        private void Mutate(Individual individual)
        {
            for (int i = 0; i < individual.Genes.Length; i++)
            {
                if (_random.NextDouble() < _mutationRate)
                {
                    individual.Genes[i] = _random.NextDouble() * (_maxValue - _minValue) + _minValue;
                }
            }
        }

        public Individual GetBestIndividual()
        {
            return _population.GetFittest();
        }
    }
}