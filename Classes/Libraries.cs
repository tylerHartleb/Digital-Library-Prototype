using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC_481_Digital_Library_Prototype.Classes
{
    public class Libraries
    {
        public Dictionary<string, Library> locations = new Dictionary<string, Library>();
        public Dictionary<string, Dictionary<string, int>> formatAvailability = new Dictionary<string, Dictionary<string, int>>();
        public Dictionary<string, Dictionary<string, int>> heldItems = new Dictionary<string, Dictionary<string, int>>();

        public Libraries()
        {
            AddLocations();
            SetFormats();
            SetHeld();
        }

        private void AddLocations()
        {
            #region NoseHill
            Library noseHill = new Library("Nose Hill")
                .SetTotalBooks(new Dictionary<string, int>() { 
                    { "the lightning thief", 5 },
                    { "the sea of monsters", 3 },
                    { "the titan's curse", 2 },
                    { "the battle of the labyrinth", 2 },
                    { "the last olympian", 0 },
                    { "daughter of the deep", 9 },
                    { "Around the World in Eighty Days".ToLower(), 3 },
                    { "Journey to the Center of the Earth".ToLower(), 0 },
                    { "A Study of History".ToLower(), 12 },
                    { "Civilization on Trial".ToLower(), 0 },
                    { "Choose Life".ToLower(), 4 },
                    { "The Making of the English Working Class".ToLower(), 1 },
                    { "Customs in Common".ToLower(), 5 },
                    { "Man's Search for Meaning".ToLower(), 23 },
                    { "The Will to Meaning".ToLower(), 11 },
                    { "Yes to Life: In Spite of Everything".ToLower(), 3 },
                    { "You Are a Badass: How to Stop Doubting Your Greatness and Start Living an Awesome Life".ToLower(), 0 },
                    { "Badass Habits: Cultivate the Awareness, Boundaries, and Daily Upgrades You Need to Make Them Stick".ToLower(), 0 },
                    { "Cooking from the Spirit: Easy, Delicious, and Joyful Plant-Based Inspirations".ToLower(), 3 },
                    { "Feeding the Soul (Because It's My Business): Finding Our Way to Joy, Love, and Freedom".ToLower(), 0 },
                    { "Seen, Loved and Heard: A Guided Journal for Feeding the Soul".ToLower(), 4 },
                    { "Ottolenghi Flavor: A Cookbook".ToLower(), 3 },
                    { "Mezcla: Recipes to Excite".ToLower(), 0 },
                    { "Still Life: A Chief Inspector Gamache Novel".ToLower(), 1 },
                    { "A Fatal Grace".ToLower(), 0 },
                    { "A Rule Against Murder".ToLower(), 0 },
                    { "The Beast Must Die".ToLower(), 0 },
                    { "A Question of Proof".ToLower(), 3 },
                    { "Fire & Blood".ToLower(), 1 },
                    { "The Name of the Wind".ToLower(), 0 },
                    { "The Wise Man's Fear".ToLower(), 3},
                    { "A Game of Thrones".ToLower(), 1 },
                    { "A Clash of Kings".ToLower(), 0},
                    { "A Storm of Swords".ToLower(), 3 },
                    { "A Feast for Crows".ToLower(), 1 },
                    { "A Dance with Dragons".ToLower(), 0 },
                    { "The Winds of Winter".ToLower(), 2 }
                })
                .SetHeldBooks(new Dictionary<string, int>() {
                    { "A Dance with Dragons".ToLower(), 6 },
                    { "A Rule Against Murder".ToLower(), 2 },
                    { "the last olympian", 3 },
                    { "Journey to the Center of the Earth".ToLower(), 1 },
                });
            #endregion

            #region Downtown
            Library downtown = new Library("Downtown")
                .SetTotalBooks(new Dictionary<string, int>() {
                    { "the lightning thief", 2 },
                    { "the sea of monsters", 0 },
                    { "the titan's curse", 2 },
                    { "the battle of the labyrinth", 2 },
                    { "the last olympian", 0 },
                    { "daughter of the deep", 0 },
                    { "Around the World in Eighty Days".ToLower(), 3 },
                    { "Journey to the Center of the Earth".ToLower(), 0 },
                    { "A Study of History".ToLower(), 0 },
                    { "Civilization on Trial".ToLower(), 0 },
                    { "Choose Life".ToLower(), 0 },
                    { "The Making of the English Working Class".ToLower(), 0 },
                    { "Customs in Common".ToLower(), 1 },
                    { "Man's Search for Meaning".ToLower(), 0 },
                    { "The Will to Meaning".ToLower(), 11 },
                    { "Yes to Life: In Spite of Everything".ToLower(), 1 },
                    { "You Are a Badass: How to Stop Doubting Your Greatness and Start Living an Awesome Life".ToLower(), 0 },
                    { "Badass Habits: Cultivate the Awareness, Boundaries, and Daily Upgrades You Need to Make Them Stick".ToLower(), 0 },
                    { "Cooking from the Spirit: Easy, Delicious, and Joyful Plant-Based Inspirations".ToLower(), 1 },
                    { "Feeding the Soul (Because It's My Business): Finding Our Way to Joy, Love, and Freedom".ToLower(), 0 },
                    { "Seen, Loved and Heard: A Guided Journal for Feeding the Soul".ToLower(), 5 },
                    { "Ottolenghi Flavor: A Cookbook".ToLower(), 4 },
                    { "Mezcla: Recipes to Excite".ToLower(), 0 },
                    { "Still Life: A Chief Inspector Gamache Novel".ToLower(), 3 },
                    { "A Fatal Grace".ToLower(), 0 },
                    { "A Rule Against Murder".ToLower(), 0 },
                    { "The Beast Must Die".ToLower(), 0 },
                    { "A Question of Proof".ToLower(), 9 },
                    { "Fire & Blood".ToLower(), 6 },
                    { "The Name of the Wind".ToLower(), 0 },
                    { "The Wise Man's Fear".ToLower(), 4},
                    { "A Game of Thrones".ToLower(), 4 },
                    { "A Clash of Kings".ToLower(), 0},
                    { "A Storm of Swords".ToLower(), 2 },
                    { "A Feast for Crows".ToLower(), 7 },
                    { "A Dance with Dragons".ToLower(), 0 },
                    { "The Winds of Winter".ToLower(), 6 }
                })
                .SetHeldBooks(new Dictionary<string, int>() {
                    { "A Dance with Dragons".ToLower(), 1 },
                    { "A Rule Against Murder".ToLower(), 0 },
                    { "the last olympian", 8 },
                    { "Journey to the Center of the Earth".ToLower(), 4 },
                });
            #endregion

            #region Fish Creek
            Library fishCreek = new Library("Fish Creek")
                .SetTotalBooks(new Dictionary<string, int>() {
                    { "the lightning thief", 2 },
                    { "the sea of monsters", 1 },
                    { "the titan's curse", 0 },
                    { "the battle of the labyrinth", 2 },
                    { "the last olympian", 0 },
                    { "daughter of the deep", 7 },
                    { "Around the World in Eighty Days".ToLower(), 7 },
                    { "Journey to the Center of the Earth".ToLower(), 0 },
                    { "A Study of History".ToLower(), 0 },
                    { "Civilization on Trial".ToLower(), 0 },
                    { "Choose Life".ToLower(), 4 },
                    { "The Making of the English Working Class".ToLower(), 1 },
                    { "Customs in Common".ToLower(), 0 },
                    { "Man's Search for Meaning".ToLower(), 23 },
                    { "The Will to Meaning".ToLower(), 1 },
                    { "Yes to Life: In Spite of Everything".ToLower(), 3 },
                    { "You Are a Badass: How to Stop Doubting Your Greatness and Start Living an Awesome Life".ToLower(), 0 },
                    { "Badass Habits: Cultivate the Awareness, Boundaries, and Daily Upgrades You Need to Make Them Stick".ToLower(), 0 },
                    { "Cooking from the Spirit: Easy, Delicious, and Joyful Plant-Based Inspirations".ToLower(), 3 },
                    { "Feeding the Soul (Because It's My Business): Finding Our Way to Joy, Love, and Freedom".ToLower(), 0 },
                    { "Seen, Loved and Heard: A Guided Journal for Feeding the Soul".ToLower(), 4 },
                    { "Ottolenghi Flavor: A Cookbook".ToLower(), 3 },
                    { "Mezcla: Recipes to Excite".ToLower(), 0 },
                    { "Still Life: A Chief Inspector Gamache Novel".ToLower(), 1 },
                    { "A Fatal Grace".ToLower(), 0 },
                    { "A Rule Against Murder".ToLower(), 0 },
                    { "The Beast Must Die".ToLower(), 0 },
                    { "A Question of Proof".ToLower(), 1 },
                    { "Fire & Blood".ToLower(), 1 },
                    { "The Name of the Wind".ToLower(), 0 },
                    { "The Wise Man's Fear".ToLower(), 3},
                    { "A Game of Thrones".ToLower(), 4 },
                    { "A Clash of Kings".ToLower(), 7},
                    { "A Storm of Swords".ToLower(), 3 },
                    { "A Feast for Crows".ToLower(), 1 },
                    { "A Dance with Dragons".ToLower(), 0 },
                    { "The Winds of Winter".ToLower(), 2 }
                })
                .SetHeldBooks(new Dictionary<string, int>() {
                    { "A Dance with Dragons".ToLower(), 1 },
                    { "A Rule Against Murder".ToLower(), 1 },
                    { "the last olympian", 0 },
                    { "Journey to the Center of the Earth".ToLower(), 1 },
                });
            #endregion

            #region Bowness
            Library bowness = new Library("Bowness")
                .SetTotalBooks(new Dictionary<string, int>() {
                    { "the lightning thief", 2 },
                    { "the sea of monsters", 3 },
                    { "the titan's curse", 2 },
                    { "the battle of the labyrinth", 2 },
                    { "the last olympian", 0 },
                    { "daughter of the deep", 7 },
                    { "Around the World in Eighty Days".ToLower(), 3 },
                    { "Journey to the Center of the Earth".ToLower(), 0 },
                    { "A Study of History".ToLower(), 12 },
                    { "Civilization on Trial".ToLower(), 0 },
                    { "Choose Life".ToLower(), 4 },
                    { "The Making of the English Working Class".ToLower(), 1 },
                    { "Customs in Common".ToLower(), 5 },
                    { "Man's Search for Meaning".ToLower(), 8 },
                    { "The Will to Meaning".ToLower(), 11 },
                    { "Yes to Life: In Spite of Everything".ToLower(), 3 },
                    { "You Are a Badass: How to Stop Doubting Your Greatness and Start Living an Awesome Life".ToLower(), 0 },
                    { "Badass Habits: Cultivate the Awareness, Boundaries, and Daily Upgrades You Need to Make Them Stick".ToLower(), 0 },
                    { "Cooking from the Spirit: Easy, Delicious, and Joyful Plant-Based Inspirations".ToLower(), 3 },
                    { "Feeding the Soul (Because It's My Business): Finding Our Way to Joy, Love, and Freedom".ToLower(), 0 },
                    { "Seen, Loved and Heard: A Guided Journal for Feeding the Soul".ToLower(), 4 },
                    { "Ottolenghi Flavor: A Cookbook".ToLower(), 3 },
                    { "Mezcla: Recipes to Excite".ToLower(), 0 },
                    { "Still Life: A Chief Inspector Gamache Novel".ToLower(), 1 },
                    { "A Fatal Grace".ToLower(), 0 },
                    { "A Rule Against Murder".ToLower(), 0 },
                    { "The Beast Must Die".ToLower(), 0 },
                    { "A Question of Proof".ToLower(), 4 },
                    { "Fire & Blood".ToLower(), 1 },
                    { "The Name of the Wind".ToLower(), 0 },
                    { "The Wise Man's Fear".ToLower(), 3},
                    { "A Game of Thrones".ToLower(), 1 },
                    { "A Clash of Kings".ToLower(), 1},
                    { "A Storm of Swords".ToLower(), 3 },
                    { "A Feast for Crows".ToLower(), 1 },
                    { "A Dance with Dragons".ToLower(), 0 },
                    { "The Winds of Winter".ToLower(), 2 }
                })
                .SetHeldBooks(new Dictionary<string, int>() {
                    { "A Dance with Dragons".ToLower(), 6 },
                    { "A Rule Against Murder".ToLower(), 2 },
                    { "the last olympian", 3 },
                    { "Journey to the Center of the Earth".ToLower(), 1 },
                });
            #endregion

            locations.Add("Nose Hill".ToLower(), noseHill);
            locations.Add("Downtown".ToLower(), downtown);
            locations.Add("Fish Creek".ToLower(), fishCreek);
            locations.Add("Bowness".ToLower(), bowness);
        }

        private void SetFormats()
        {
            formatAvailability = new Dictionary<string, Dictionary<string, int>>() {
                { "the lightning thief", new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("the lightning thief".ToLower()) },
                    { "smartphone", 3 },
                    { "headphone", 2 }
                }},
                { "the sea of monsters", new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("the sea of monsters".ToLower()) },
                    { "smartphone", 0 },
                    { "headphone", 1 }
                }},
                { "the titan's curse", new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("the titan's curse".ToLower()) },
                    { "smartphone", 1 },
                    { "headphone", 0 }
                }},
                { "the battle of the labyrinth", new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("the battle of the labyrinth".ToLower()) },
                    { "smartphone", 2 },
                    { "headphone", 0 }
                }},
                { "the last olympian", new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("the last olympian".ToLower()) },
                    { "smartphone", 0 },
                    { "headphone", 1 }
                } },
                { "daughter of the deep", new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("daughter of the deep".ToLower()) },
                    { "smartphone", 3 },
                    { "headphone", 0 }
                } },
                { "Around the World in Eighty Days".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("Around the World in Eighty Days".ToLower()) },
                    { "smartphone", 3 },
                    { "headphone", 0 }
                }},
                { "Journey to the Center of the Earth".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("Journey to the Center of the Earth\"".ToLower()) },
                    { "smartphone", 3 },
                    { "headphone", 1 }
                }},
                { "A Study of History".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("A Study of History".ToLower()) },
                    { "smartphone", 5 },
                    { "headphone", 0 }
                }},
                { "Civilization on Trial".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("Civilization on Trial".ToLower()) },
                    { "smartphone", 1 },
                    { "headphone", 0 }
                }},
                { "Choose Life".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("Choose Life".ToLower()) },
                    { "smartphone", 1 },
                    { "headphone", 0 }
                }},
                { "The Making of the English Working Class".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("The Making of the English Working Class".ToLower()) },
                    { "smartphone", 0 },
                    { "headphone", 1 }
                }},
                { "Customs in Common".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("Customs in Common".ToLower()) },
                    { "smartphone", 0 },
                    { "headphone", 1 }
                }},
                { "Man's Search for Meaning".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("Man's Search for Meaning".ToLower()) },
                    { "smartphone", 0 },
                    { "headphone", 1 }
                }},
                { "The Will to Meaning".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("The Will to Meaning".ToLower()) },
                    { "smartphone", 0 },
                    { "headphone", 0 }
                }},
                { "Yes to Life: In Spite of Everything".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("Yes to Life: In Spite of Everything".ToLower()) },
                    { "smartphone", 0 },
                    { "headphone", 0 }
                } },
                { "You Are a Badass: How to Stop Doubting Your Greatness and Start Living an Awesome Life".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("You Are a Badass: How to Stop Doubting Your Greatness and Start Living an Awesome Life".ToLower()) },
                    { "smartphone", 0 },
                    { "headphone", 0 }
                } },
                { "Badass Habits: Cultivate the Awareness, Boundaries, and Daily Upgrades You Need to Make Them Stick".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("Badass Habits: Cultivate the Awareness, Boundaries, and Daily Upgrades You Need to Make Them Stick".ToLower()) },
                    { "smartphone", 0 },
                    { "headphone", 1 }
                } },
                { "Cooking from the Spirit: Easy, Delicious, and Joyful Plant-Based Inspirations".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("Cooking from the Spirit: Easy, Delicious, and Joyful Plant-Based Inspirations".ToLower()) },
                    { "smartphone", 7 },
                    { "headphone", 0 }
                } },
                { "Feeding the Soul (Because It's My Business): Finding Our Way to Joy, Love, and Freedom".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("Feeding the Soul (Because It's My Business): Finding Our Way to Joy, Love, and Freedom".ToLower()) },
                    { "smartphone", 51 },
                    { "headphone", 0 }
                } },
                { "Seen, Loved and Heard: A Guided Journal for Feeding the Soul".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("Seen, Loved and Heard: A Guided Journal for Feeding the Soul".ToLower()) },
                    { "smartphone", 3 },
                    { "headphone", 1 }
                } },
                { "Ottolenghi Flavor: A Cookbook".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("Ottolenghi Flavor: A Cookbook".ToLower()) },
                    { "smartphone", 3 },
                    { "headphone", 0 }
                } },
                { "Mezcla: Recipes to Excite".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("Mezcla: Recipes to Excite".ToLower()) },
                    { "smartphone", 3 },
                    { "headphone", 6 }
                }},
                { "Still Life: A Chief Inspector Gamache Novel".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("Still Life: A Chief Inspector Gamache Novel".ToLower()) },
                    { "smartphone", 4 },
                    { "headphone", 2 }
                }},
                { "A Fatal Grace".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("A Fatal Grace".ToLower()) },
                    { "smartphone", 31 },
                    { "headphone", 2 }
                }},
                { "A Rule Against Murder".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("A Rule Against Murder".ToLower()) },
                    { "smartphone", 21 },
                    { "headphone", 2 }
                }},
                { "The Beast Must Die".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("The Beast Must Die".ToLower()) },
                    { "smartphone", 1 },
                    { "headphone", 2 }
                }},
                { "A Question of Proof".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("A Question of Proof".ToLower()) },
                    { "smartphone", 3 },
                    { "headphone", 2 }
                }},
                { "Fire & Blood".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("Fire & Blood".ToLower()) },
                    { "smartphone", 3 },
                    { "headphone", 2 }
                }},
                { "The Name of the Wind".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("The Name of the Wind".ToLower()) },
                    { "smartphone", 3 },
                    { "headphone", 2 }
                }},
                { "The Wise Man's Fear".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("The Wise Man's Fear".ToLower()) },
                    { "smartphone", 3 },
                    { "headphone", 2 }
                }},
                { "A Game of Thrones".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("A Game of Thrones".ToLower()) },
                    { "smartphone", 3 },
                    { "headphone", 2 }
                }},
                { "A Clash of Kings".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("A Clash of Kings".ToLower()) },
                    { "smartphone", 3 },
                    { "headphone", 2 }
                }},
                { "A Storm of Swords".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("A Storm of Swords".ToLower()) },
                    { "smartphone", 3 },
                    { "headphone", 2 }
                }},
                { "A Feast for Crows".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("A Feast for Crows".ToLower()) },
                    { "smartphone", 3 },
                    { "headphone", 2 }
                }},
                { "A Dance with Dragons".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("A Dance with Dragons".ToLower()) },
                    { "smartphone", 3 },
                    { "headphone", 2 }
                }},
                { "The Winds of Winter".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalAvailable("The Winds of Winter".ToLower()) },
                    { "smartphone", 3 }
                }}
            };
        }

        private void SetHeld()
        {
            heldItems = new Dictionary<string, Dictionary<string, int>>() {
                { "the last olympian", new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalHeld("the last olympian".ToLower()) },
                    { "smartphone", 4 },
                    { "headphone", 0 }
                } },
                { "Journey to the Center of the Earth".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalHeld("Journey to the Center of the Earth\"".ToLower()) },
                    { "smartphone", 0 },
                    { "headphone", 0 }
                }},
                { "A Rule Against Murder".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalHeld("A Rule Against Murder".ToLower()) },
                    { "smartphone", 0 },
                    { "headphone", 0 }
                }},
                { "A Dance with Dragons".ToLower(), new Dictionary<string, int>() {
                    { "book", GetTotalPhysicalHeld("A Dance with Dragons".ToLower()) },
                    { "smartphone", 0 },
                    { "headphone", 0 }
                }},
            };
        }

        public int GetTotalPhysicalAvailable(string book)
        {
            int numcopies = 0;
            foreach(Library lib in locations.Values)
            {
                numcopies += lib.AvailableCopies(book);
            }
            return numcopies;
        }

        public int GetTotalPhysicalHeld(string book)
        {
            int numcopies = 0;
            foreach (Library lib in locations.Values)
            {
                numcopies += lib.HeldCopies(book);
            }
            return numcopies;
        }
    }
}
