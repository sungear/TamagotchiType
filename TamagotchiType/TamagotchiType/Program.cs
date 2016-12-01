using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiType
{
    //STATS ET ACTIONS
    public struct Stats
    {
        //CREATION DES STATS
        public int MaxRassasiement;
        public int MaxHydratation;
        public int MaxBonheur;
        public int MaxHygiene;
        public int MaxEnergie;

        public int MinRassasiement;
        public int MinHydratation;
        public int MinBonheur;
        public int MinHygiene;
        public int MinEnergie;

        public int Rassasiement;
        public int Hydratation;
        public int Bonheur;
        public int Hygiene;
        public int Energie;
        public int Experience;
        public int Niveau;
        public int Jour;

        public bool mort;
        public int[] ConditionsMort;


        //CREATION DES ACTIONS

        //NOURRIR
        public void Nourrir()
        {
            Rassasiement += 3;
            Hydratation -= 2;
            Bonheur += 1;
            Hygiene -= 2;
            Energie -= 1;
        }//nourrir

        //DONNER À BOIRE
        public void Hydrater()
        {
            Rassasiement += 1;
            Hydratation += 3;
            Bonheur += 1;
            Hygiene += 1;
        }//boire

        //CARESSER
        public void Caresser()
        {
            Bonheur += 2;
        }//caresser

        //JOUER
        public void Jouer()
        {
            Rassasiement -= 3;
            Hydratation -= 4;
            Bonheur += 4;
            Hygiene -= 5;
            Energie -= 3;
        }//jouer

        //ENTRAINER
        public void Entrainer()
        {
            Rassasiement -= 4;
            Hydratation -= 5;
            Bonheur -= 8;
            Hygiene -= 6;
            Energie -= 5;
            Experience += 5;
        }//entrainer

        //FAIRE LA TOILETTE
        public void Nettoyer()
        {
            Hydratation -= 1;
            Bonheur += 2;
            Hygiene += 5;
            Energie += 1;
        }//nettoyer

        //ENDORMIR
        public void Endormir()
        {
            Rassasiement -= 2;
            Hydratation -= 3;
            Bonheur += 3;
            Hygiene -= 3;
            Energie += 4;
            Experience += 1;
            Jour += 1;

            PourMourir();
        }//endormir

        //POUR NE PAS DEPASSER LES VALEURS MAXIMALES
        public void Maximum()
        {
            Rassasiement = Math.Min(Rassasiement, MaxRassasiement);
            Hydratation = Math.Min(Hydratation, MaxHydratation);
            Bonheur = Math.Min(Bonheur, MaxBonheur);
            Hygiene = Math.Min(Hygiene, MaxHygiene);
            Energie = Math.Min(Energie, MaxEnergie);
        }//maximum

        //POUR NE PAS TOMBER DANS LES NEGATIFS
        public void Minimum()
        {
            Rassasiement = Math.Max(Rassasiement, MinRassasiement);
            Hydratation = Math.Max(Hydratation, MinHydratation);
            Bonheur = Math.Max(Bonheur, MinBonheur);
            Hygiene = Math.Max(Hygiene, MinHygiene);
            Energie = Math.Max(Energie, MinEnergie);
        }//minimum

        //MONTER DE NIVEAU
        public void MonterNiveau()
        {
            if (Experience > 20)
            {
                int BonusXP = Experience - 20;
                Experience = 20;
                Niveau++;
                Experience = BonusXP;
            }
        }//level up

        //CONDITIONS DE MORT
        public void PourMourir()
        {
            if (Hydratation < 1)
            {
                ConditionsMort[0]++;
                if (ConditionsMort[0] > 1)
                {
                    mort = true;
                }
            }

            if (Rassasiement < 1)
            {
                ConditionsMort[1]++;
                if (ConditionsMort[1] > 3)
                {
                    mort = true;
                }
            }

            if (Bonheur < 1)
            {
                ConditionsMort[2]++;
                if (ConditionsMort[2] > 5)
                {
                    mort = true;
                }
            }

            if (Hygiene < 1)
            {
                ConditionsMort[3]++;
                if (ConditionsMort[3] > 7)
                {
                    mort = true;
                }
            }
        }

    }//struct Stats


    class Program
    {
        static void Main(string[] args)
        {
            //INITIALISATION DES STATS
            Stats stats = new Stats();
            stats.MaxRassasiement = 15;
            stats.MaxHydratation = 15;
            stats.MaxBonheur = 15;
            stats.MaxHygiene = 15;
            stats.MaxEnergie = 15;

            stats.Rassasiement = 15;
            stats.Hydratation = 15;
            stats.Bonheur = 15;
            stats.Hygiene = 15;
            stats.Energie = 15;
            stats.Experience = 0;
            stats.Niveau = 0;
            stats.Jour = 1;

            stats.mort = false;
            stats.ConditionsMort = new int[4];

            //ON ENTRE DANS LE JEU
            while (!stats.mort)
            {
                bool MENU = false;
                //AFFICHAGE DU MENU STATS + ACTIONS
                while (!MENU && !stats.mort)
                {
                    Console.Clear();

                    Console.WriteLine("   ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                    Console.WriteLine("   █                                                      █");
                    Console.WriteLine("   █ Appuyer sur ENTER pour consulter sur le menu Help    █");
                    Console.WriteLine(String.Format("   █ {0, -52} █", "État de rassasiement : " + stats.Rassasiement + "/15"));
                    Console.WriteLine(String.Format("   █ {0, -52} █", "État d'hydratation : " + stats.Hydratation + "/15"));
                    Console.WriteLine(String.Format("   █ {0, -52} █", "Bonheur : " + stats.Bonheur + "/15"));
                    Console.WriteLine(String.Format("   █ {0, -52} █", "Hygiène : " + stats.Hygiene + "/15"));
                    Console.WriteLine(String.Format("   █ {0, -52} █", "Energie : " + stats.Energie + "/15"));
                    Console.WriteLine(String.Format("   █ {0, -52} █", "Expérience : " + stats.Experience + "/20"));
                    Console.WriteLine(String.Format("   █ {0, -52} █", "Niveau : " + stats.Niveau));
                    Console.WriteLine(String.Format("   █ {0, -52} █", "Jour : " + stats.Jour));
                    Console.WriteLine("   █                                                      █");
                    Console.WriteLine("   ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀\n");

                    //AFFICHECHAGE DU TAMAGOTCHI
                    Console.WriteLine("                            ▀▀▀▀▀                          ");
                    Console.WriteLine("                      ▀              ▀               ");
                    Console.WriteLine("                     ▀                ▀                ");
                    Console.WriteLine("                    ▀     █      █     ▀               ");
                    Console.WriteLine("                   ▀                    ▀               ");
                    Console.WriteLine("                   ▀                    ▀               ");
                    Console.WriteLine("                   ▀                    ▀               ");
                    Console.WriteLine("                    ▀       ▀▀▀        ▀              ");
                    Console.WriteLine("                     ▀                ▀                 ");
                    Console.WriteLine("                      ▀              ▀               ");
                    Console.WriteLine("                         ▀▀▀▀▀▀▀▀▀▀                        ");


                    //LES ACTIONS (TOUCHES CLIVIERS) + LEUR EFFETS
                    ConsoleKeyInfo infotouche = Console.ReadKey(true);
                    switch (infotouche.Key)
                    {
                        case ConsoleKey.Enter:
                            MENU = true;
                            break;
                        case ConsoleKey.NumPad1:
                            stats.Nourrir();
                            break;
                        case ConsoleKey.NumPad2:
                            stats.Hydrater();
                            break;
                        case ConsoleKey.NumPad3:
                            stats.Caresser();
                            break;
                        case ConsoleKey.NumPad4:
                            stats.Jouer();
                            break;
                        case ConsoleKey.NumPad5:
                            stats.Entrainer();
                            break;
                        case ConsoleKey.NumPad6:
                            stats.Nettoyer();
                            break;
                        case ConsoleKey.NumPad7:
                            stats.Endormir();
                            break;
                    }//switch

                    stats.Maximum();
                    stats.Minimum();
                    stats.MonterNiveau();

                }// while(!MENU) ==> FALSE !

                //AFFICHAGE DU MENU HELP
                while (MENU && !stats.mort)
                {
                    Console.Clear();

                    //CONTENU DU MENU
                    Console.WriteLine("   ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                    Console.WriteLine("   █                                                      █");
                    Console.WriteLine("   █ Appuyer sur 1 pour nourrir votre Tamagochi           █");
                    Console.WriteLine("   █ Appuyer sur 2 pour donner à boire à votre Tamagochi  █");
                    Console.WriteLine("   █ Appuyer sur 3 pour caresser votre Tamagochi          █");
                    Console.WriteLine("   █ Appuyer sur 4 pour jouer avec votre Tamagochi        █");
                    Console.WriteLine("   █ Appuyer sur 5 pour entraîner votre Tamagochi         █");
                    Console.WriteLine("   █ Appuyer sur 6 pour faire la toilette votre Tamagochi █");
                    Console.WriteLine("   █ Appuyer sur 7 pour endormir de votre Tamagochi       █");
                    Console.WriteLine("   █ Appuyer sur ENTER pour retourner au Menu Stats       █");
                    Console.WriteLine("   █                                                      █");
                    Console.WriteLine("   ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");

                    //SORTIR DE LA BOUCLE → ALLER AU MENU STATS
                    ConsoleKeyInfo infotouche = Console.ReadKey(true);
                    if (infotouche.Key == ConsoleKey.Enter)
                    {
                        MENU = false;
                    }
                }// while(MENU) ==> TRUE !

            }//while(true)

            if (stats.mort)
            {
                Console.Clear();
                Console.WriteLine("Your Tamagochi is dead");
                Console.ReadKey();
            }

        }// function Main
    }// class Program
}// Project
