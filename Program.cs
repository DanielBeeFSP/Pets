string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

int maxPets = 8;
string? readResult;
string menuSelection = "";

string[,] ourAnimals = new string[maxPets, 6];

for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream female golden retriever weighing about 65 pounds. housebroken";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses";
            animalNickname = "lola";
            break;
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;
        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

Console.Clear();

do
{
    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    // Console.WriteLine($"You have selected menu option {menuSelection}.");
    // Console.WriteLine("Press the Enter key to continue.");

    // // pause code execution
    // readResult = Console.ReadLine();

    switch (menuSelection)
    {
        case "1":
            for (int x = 0; x < maxPets; x++)
            {
                if (ourAnimals[x, 0] != "ID #: ")
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[x, j]);
                    }
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "2":
            string anotherPet = "y";
            int petCount = 0;
            for (int z = 0; z < maxPets; z++)
            {
                if (ourAnimals[z, 0] != "ID #: ")
                {
                    petCount++;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pet(s) that need homes. We can manage {maxPets - petCount} more pets.");
            }

            while (anotherPet == "y" && petCount < maxPets)
            {
                bool validEntry = false;
                animalAge = "";
                animalPhysicalDescription = "";
                animalPersonalityDescription = "";
                animalNickname = "";
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry:");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            validEntry = false;
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();
                do
                {
                    int petAge;
                    Console.WriteLine("Enter the pet's age or enter '?' if unknown:");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalAge = readResult;
                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);
                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, colour, gender, weight, housebroken):");
                    readResult = Console.ReadLine();
                    animalPhysicalDescription = readResult?.Trim().ToLower() ?? "";
                    if (animalPhysicalDescription == "" || animalPhysicalDescription == null)
                    {
                        animalPhysicalDescription = "tbd";
                    }
                } while (animalPhysicalDescription == "");
                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes, dislikes, tricks, energy level):");
                    readResult = Console.ReadLine();
                    animalPersonalityDescription = readResult?.Trim().ToLower() ?? "";
                    if (animalPersonalityDescription == "")
                    {
                        animalPersonalityDescription = "tbd";
                    }
                } while (animalPersonalityDescription == "");
                do
                {
                    Console.WriteLine("Enter a nickname for the pet:");
                    readResult = Console.ReadLine();
                    animalNickname = readResult?.Trim().ToLower() ?? "";
                    if (animalNickname == "")
                    {
                        animalNickname = "tbd";
                    }
                } while (animalNickname == "");
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality " + animalPersonalityDescription;
                petCount++;
                if (petCount < maxPets)
                {
                    Console.WriteLine("Do you want to enter info for another pet?");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            break;
        case "3":
            for (int x = 0; x < maxPets; x++)
            {
                if (ourAnimals[x, 0] == "ID #: ")
                {
                    continue;
                }

                Console.WriteLine($"\n{ourAnimals[x, 0]}");

                if (!int.TryParse(ourAnimals[x, 2], out _))
                {
                    Console.WriteLine("Your pet age is not a number.");
                    Console.WriteLine($"Your existing age is {ourAnimals[x, 2]}, enter another:");
                    ourAnimals[x, 2] = Console.ReadLine()?.Trim() ?? "";
                    while (!int.TryParse(ourAnimals[x, 2], out _))
                    {
                        Console.WriteLine("Your pet age is not a number.");
                        Console.WriteLine($"Your existing age is {ourAnimals[x, 2]}, enter another:");
                        ourAnimals[x, 2] = Console.ReadLine()?.Trim() ?? "";
                    }
                }

                if (string.IsNullOrWhiteSpace(ourAnimals[x, 4]))
                {
                    Console.WriteLine("You must enter a physical description");
                    ourAnimals[x, 4] = Console.ReadLine()?.Trim() ?? "";

                    while (string.IsNullOrWhiteSpace(ourAnimals[x, 4]))
                    {
                        Console.WriteLine("You must enter a physical description");
                        ourAnimals[x, 4] = Console.ReadLine()?.Trim() ?? "";
                    }
                }
            }
            Console.WriteLine("All ages and physical descriptions are now complete.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "4":
            Console.WriteLine("this app feature is comingsoon - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "5":
            Console.WriteLine("this app feature is comingsoon - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "6":
            Console.WriteLine("this app feature is comingsoon - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "7":
            Console.WriteLine("this app feature is comingsoon - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "8":
            Console.WriteLine("this app feature is comingsoon - please check back to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        default:
            break;
    }
} while (menuSelection != "exit");