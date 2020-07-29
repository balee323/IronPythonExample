﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace IronPythonExample
{
    class CreateGameInstance
    {

        private ScriptEngine _pythonEngine;
        dynamic _game;

        public CreateGameInstance()
        {
            _pythonEngine = IronPython.Hosting.Python.CreateEngine();
        }


        public void SpinUpGameInstance()
        {
            _pythonEngine.SetSearchPaths(new[] { "PythonScripts" }); //which folder
            var scope = _pythonEngine.CreateScope(); //create a scope for the engine
            scope.ImportModule("GuessingGame"); //import the module
            _pythonEngine.Execute("game = GuessingGame.GuessingGame()", scope); //create an object (module.class)
            _game = scope.GetVariable("game"); //get the object   

            var rand = new Random(DateTime.Now.Millisecond);
            var randomNumber = rand.Next(0, 10);
            _game.set_number_to_guess(randomNumber);

            var response = _game.start_game();
            Console.WriteLine(response);
        }


        public void MakeAGuess(int number)
        {
            var response = _game.make_guess(number).ToString();
            Console.WriteLine(response);
        }



    }
}
