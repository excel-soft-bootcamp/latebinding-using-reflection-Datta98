using System;

namespace GameApplication
{

    public enum Options
    {
        BASIC = 1, INTERMEDIATE, ADVANCED
    }


    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int invalid_check = 0;
            do
            {

                Console.WriteLine("Word Guess Game");

                string message = string.Format("Enter Your Choice {0}->Basic , {1}->Intermediate ,{2}->Advanced", Options.BASIC, Options.INTERMEDIATE, Options.ADVANCED);// 1->Basic,2->Intermediate
                                                                                                                                                                         //String Interpollation 
                string displayMessage = $"Enter Your Choice {(int)Options.BASIC}->Basic,{(int)Options.INTERMEDIATE}->Intermediate,{(int)Options.ADVANCED}->Advanced";
                Console.WriteLine(displayMessage);
                try
                {
                    Options _choice = (Options)Int32.Parse(Console.ReadLine());
                    x = Convert.ToInt32(_choice);
                    switch (_choice )
                    {
                        case Options.BASIC:
                            Console.WriteLine("Basic Level");
                            //Use Reflection  
                            //Assembly Load
                            System.Reflection.Assembly basicLevelLib =
                            System.Reflection.Assembly.LoadFile(@"C:\Users\shridatta.r\Documents\Visual Studio 2019\Bootcamp Practice\LevelLibs\BasicLevelLib.dll");
                            // Search For Class - BasicLevelType
                            System.Type basicLevelTypeClassRef = basicLevelLib.GetType("BasicLevelLib.BasicLevelType");
                            if (basicLevelTypeClassRef != null)
                            {
                                if (basicLevelTypeClassRef.IsClass)
                                {
                                    //Instantiate Type
                                    //BasicLevelLib.BasicLevelType objref=new BasicLevelLib.BasicLevelType() ; Early Binding
                                    Object objRef = System.Activator.CreateInstance(basicLevelTypeClassRef); //LateBinding Code
                                                                                                             //Discove Method
                                    System.Reflection.MethodInfo _methodRef = basicLevelTypeClassRef.GetMethod("Play");
                                    if (!_methodRef.IsStatic)
                                    {
                                        //Invoke NonStatic Method
                                        // string Play(string playerName, int earlierPoints){}
                                        //object result=  _methodRef.Invoke(objRef, new object[] {"Tom",20 });
                                        object result = _methodRef.Invoke(objRef, new object[] { });
                                        Console.WriteLine(result.ToString());
                                    }

                                }

                            }
                            Console.ReadKey();
                            break;



                        case Options.INTERMEDIATE:
                            Console.WriteLine("Intermediate Level");

                            System.Reflection.Assembly intermediateLevelLib =
                            System.Reflection.Assembly.LoadFile(@"C:\Users\shridatta.r\Documents\Visual Studio 2019\Bootcamp Practice\LevelLibs\IntermediateLevelLib.dll");

                            System.Type intermediateLevelTypeClassRef = intermediateLevelLib.GetType("IntermediateLevelLib.IntermediateLevelType");
                            if (intermediateLevelTypeClassRef != null)
                            {
                                if (intermediateLevelTypeClassRef.IsClass)
                                {
                                    Object objRef = System.Activator.CreateInstance(intermediateLevelTypeClassRef);

                                    System.Reflection.MethodInfo methodRef = intermediateLevelTypeClassRef.GetMethod("Start");
                                    if (!methodRef.IsStatic)
                                    {
                                        Object result = methodRef.Invoke(objRef, new object[1] { "Kiran" });
                                        Console.WriteLine(result.ToString());
                                    }

                                }
                            }
                            Console.ReadKey();
                            break;



                        case Options.ADVANCED:
                            Console.WriteLine("Advanced Level");

                            System.Reflection.Assembly advanceLevelLib =
                            System.Reflection.Assembly.LoadFile(@"C:\Users\shridatta.r\Documents\Visual Studio 2019\Bootcamp Practice\LevelLibs\AdvancedLevelLib.dll");

                            System.Type advanceLevelTypeClassRef = advanceLevelLib.GetType("AdvancedLevelLib.AdvancedLevelType");
                            if (advanceLevelTypeClassRef != null)
                            {
                                if (advanceLevelTypeClassRef.IsClass)
                                {
                                    Object objRef = System.Activator.CreateInstance(advanceLevelTypeClassRef);
                                    System.Reflection.MethodInfo methodRef = advanceLevelTypeClassRef.GetMethod("Begin");
                                    if (!methodRef.IsStatic)
                                    {
                                        Object result = methodRef.Invoke(objRef, new object[2] { "Avinash", 50 });
                                        Console.WriteLine(result.ToString());
                                    }
                                }
                            }
                            Console.ReadKey();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();



                    }
                }
                catch
                {
                    invalid_check = invalid_check + 1;
                    if (invalid_check < 3)
                    {
                        Console.WriteLine("Invalid Choice ");
                    }
                    else
                    {
                        Console.WriteLine("You Have Reached Max Attempts");
                        Console.ReadKey();
                        break;
                    }

                }

            } while (x > 3);

        }

    }
}


