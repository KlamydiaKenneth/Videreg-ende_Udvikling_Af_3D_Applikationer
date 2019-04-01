using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pokemon> roster = new List<Pokemon>();
            List<Move> Grass = new List<Move>();
            List<Move> Fire = new List<Move>();
            List<Move> Water = new List<Move>();

            //Assigning the different moves according to pokemon type
            Grass.Add(new Move("Cut"));
            Grass.Add(new Move("Razor Leaf"));

            Fire.Add(new Move("Ember"));
            Fire.Add(new Move("Fire Blast"));

            Water.Add(new Move("Bubble"));
            Water.Add(new Move("Bite"));

            // INITIALIZE YOUR THREE POKEMONS HERE
            //For balance reasons i adjusted Both Bulbasaur and Squirtles defense to 46 and 45 respectively, so we sont get 50+ turn games.
            roster.Add(new Pokemon("Bulbasaur", "Grass", 5, 49, 46, 45, Elements.Grass, Grass));
            roster.Add(new Pokemon("Charmander", "Fire", 5, 52, 43, 39, Elements.Fire, Fire));
            roster.Add(new Pokemon("Squirtle", "Water", 5, 50, 45, 44, Elements.Water, Water));

            Console.WriteLine("Welcome to the world of Pokemon!\nThe available commands are list/fight/heal/quit \nlist shows you the available" +
                " Pokemon, \nfight starts the battle and makes you choose which pokemon are going to fight, \nheal will heal all the pokemon currently" +
                "not in combat (used after a victory or defeat to play again), \nquit makes you quit the application.");

            while (true)
            {
                Console.WriteLine("\nPlese enter a command");
                switch (Console.ReadLine())
                {
                    case "list":
                        // PRINT THE POKEMONS IN THE ROSTER HERE
                        Console.WriteLine("Available Pokemon:");
                        foreach (Pokemon pokemon in roster)
                        {
                            Console.WriteLine(pokemon.Name);
                        }
                        break;

                    case "fight":
                        //PRINT INSTRUCTIONS AND POSSIBLE POKEMONS (SEE SLIDES FOR EXAMPLE OF EXECUTION)
                        Console.Write("Choose who should fight.\nWrite the Pokemons names with a single space between them example: Squirtle Charmander" +
                            "\nThe first Pokemon is the one you will be controlling, the second one is the opponent." +
                            "\nYou can't choose the same Pokemon for each team." +
                            "\n\nPokemons to choose from:\n");

                        foreach (Pokemon pokemon in roster)
                        {
                            Console.WriteLine(pokemon.Name);
                        }

                        //READ INPUT, REMEMBER IT SHOULD BE TWO POKEMON NAMES
                        string input = Console.ReadLine();
                        string[] chosenPokemons;
                        char[] splitchar = { ' ' };

                        chosenPokemons = input.Split(splitchar);
                        Console.WriteLine(chosenPokemons);

                        //BE SURE TO CHECK THE POKEMON NAMES THE USER WROTE ARE VALID (IN THE ROSTER) AND IF THEY ARE IN FACT 2!
                        Pokemon player = null;
                        Pokemon enemy = null;

                        if (chosenPokemons.Count() == 2)
                        {
                            if (chosenPokemons.ElementAt(0) == "Bulbasaur")
                            {
                                player = roster.ElementAt(0);
                            }

                            else if (chosenPokemons.ElementAt(0) == "Charmander")
                            {
                                player = roster.ElementAt(1);
                            }

                            else if (chosenPokemons.ElementAt(0) == "Squirtle")
                            {
                                player = roster.ElementAt(2);
                            }

                            else
                            {
                                player = null;
                            }

                            if (chosenPokemons.ElementAt(1) == "Bulbasaur")
                            {
                                enemy = roster.ElementAt(0);
                            }

                            else if (chosenPokemons.ElementAt(1) == "Charmander")
                            {
                                enemy = roster.ElementAt(1);
                            }

                            else if (chosenPokemons.ElementAt(1) == "Squirtle")
                            {
                                enemy = roster.ElementAt(2);
                            }

                            else
                            {
                                enemy = null;
                            }
                        }

                        

                        //if everything is fine and we have 2 pokemons let's make them fight
                        if (player != null && enemy != null && player != enemy)
                        {
                            Console.WriteLine("A wild " + enemy.Name + " appears!");
                            Console.Write(player.Name + " I choose you! \n");

                            //BEGIN FIGHT LOOP
                            while (player.Hp > 0 && enemy.Hp > 0)
                            {
                                //PRINT POSSIBLE MOVES
                                Console.Write("\nWhat move should we use?\n");

                                int count = 0;
                                foreach (Move ability in player.Moves)
                                {
                                    Console.WriteLine("[" + count + "] " + ability.Name);
                                    count++;
                                }

                                //GET USER ANSWER, BE SURE TO CHECK IF IT'S A VALID MOVE, OTHERWISE ASK AGAIN
                                int move = -1;
                                switch (Console.ReadLine())
                                {
                                    case "0":
                                        move = 0;
                                        break;

                                    case "1":
                                        move = 1;
                                        break;

                                    default:
                                        Console.WriteLine("Invalid Move");
                                        break;
                                
                                }
                                //CALCULATE AND APPLY DAMAGE
                                float damage = player.Attack(enemy);

                                //print the move and damage
                                Console.WriteLine(player.Name + " uses " + player.Moves[move].Name + ". " + enemy.Name + " loses " + damage + " HP");
                                Console.WriteLine(enemy.Name + " HP: " + enemy.Hp + "/" + enemy.maxHP);

                                //if the enemy is not dead yet, it attacks
                                if (enemy.Hp > 0)
                                {
                                    //CHOOSE A RANDOM MOVE BETWEEN THE ENEMY MOVES AND USE IT TO ATTACK THE PLAYER
                                    Random rand = new Random();
                                    /*the C# random is a bit different than the Unity random
                                     * you can ask for a number between [0,X) (X not included) by writing
                                     * rand.Next(X) 
                                     * where X is a number 
                                     */
                                    int enemyMove = -1;

                                    int randomAttack;
                                    randomAttack = rand.Next(0, 2);
                                    if (randomAttack == 0)
                                    {
                                        enemyMove = 0;
                                    }

                                    else if (randomAttack == 1)
                                    {
                                        enemyMove = 1;
                                    }

                                    float enemyDamage = enemy.Attack(player);

                                    //print the move and damage
                                    Console.WriteLine(enemy.Name + " uses " + enemy.Moves[enemyMove].Name + ". " + player.Name + " loses " + enemyDamage + " HP");
                                    Console.WriteLine(player.Name + " HP: " + player.Hp + "/" + player.maxHP);
                                }
                            }
                            //The loop is over, so either we won or lost
                            if (enemy.Hp <= 0)
                            {
                                Console.WriteLine(enemy.Name + " faints, you won!" +
                                    "\n" + player.Name + " HP: " + player.Hp + "/" + player.maxHP);
                            }
                            else
                            {
                                Console.WriteLine(player.Name + " faints, you lost..." +
                                    "\n" + enemy.Name + " HP: " + enemy.Hp + "/" + enemy.maxHP);
                            }
                        }
                        //otherwise let's print an error message
                        else
                        {
                            Console.WriteLine("Invalid pokemons");
                        }
                        break;

                    case "heal":
                        //RESTORE ALL POKEMONS IN THE ROSTER
                        foreach (Pokemon pokemon in roster)
                        {
                            pokemon.Hp = pokemon.maxHP;
                        }

                        Console.WriteLine("All pokemons have been healed");
                        break;

                    case "quit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
