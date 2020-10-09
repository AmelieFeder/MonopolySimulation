using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fclp;
using Monopoly_Simulation.Model;
using Monopoly_Simulation.Reporting;
using Newtonsoft.Json;
using ShellProgressBar;

namespace Monopoly_Simulation
{
    class Program
    {
        private const int DefaultIterations = 10_000_000;
        
        static void Main(string[] args)
        {
            var commandLineArgs = ParseCommandLineArguments(args);
            
            Simulation simulation = CreateSimulation(commandLineArgs.Iterations);
            
            simulation.Simulate();

            simulation.Reporter.PrintReport();
        }

        private static CommandLineArgs ParseCommandLineArguments(string[] args)
        {
            var commandLineParser = new FluentCommandLineParser<CommandLineArgs>();

            commandLineParser
                .Setup(arg => arg.Iterations)
                .As('i', "iterations")
                .SetDefault(DefaultIterations)
                .WithDescription("The number of simulation iterations.");

            commandLineParser.SetupHelp("?", "help")
                .Callback(text => Console.WriteLine(text));

            ICommandLineParserResult result = commandLineParser.Parse(args);

            if (result.HelpCalled)
            {
                Environment.Exit(0);
            }
            
            if (result.HasErrors)
            {
                Environment.Exit(1);
            }

            return commandLineParser.Object;
        }

        private static Simulation CreateSimulation(int numberOfIterations)
        {
            CardDeck redCardDeck = new CardDeck(DataLoader.LoadRedCards().ToList());
            CardDeck greenCardDeck = new CardDeck(DataLoader.LoadGreenCards().ToList());

            List<Space> spaces = DataLoader.LoadSpaces().ToList();
            Gameboard gameboard = new Gameboard(spaces);
            
            Die die = Die.CreateSixEyedDie();
            Dice dice = new Dice(die, die);
            
            IReporter reporter = CreateReporter(spaces, numberOfIterations);

            var simulation = new Simulation(gameboard, redCardDeck, greenCardDeck, dice, reporter);
            simulation.NumberOfIterations = numberOfIterations;
            
            return simulation;
        }

        private static IReporter CreateReporter(List<Space> spaces, int numberOfIterations)
        {
            var progressBarOptions = new ProgressBarOptions
            {
                ForegroundColor = ConsoleColor.Yellow,
                ForegroundColorDone = ConsoleColor.DarkGreen,
                
                BackgroundColor = ConsoleColor.DarkGray,
                BackgroundCharacter = '\u2593'
            };
            
            IReporter reporter = new Reporter(spaces, new ProgressBar(numberOfIterations, "Simulating...", progressBarOptions));
            //IReporter reporter = new DebugReporter(spaces);

            return reporter;
        }
    }
}