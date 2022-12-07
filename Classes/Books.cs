﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC_481_Digital_Library_Prototype.Classes
{
    public class Books
    {
        private static Books _instance = new Books();

        private Dictionary<string, Book> _books = new Dictionary<string, Book>();
        private Dictionary<string, List<Book>> _booksCategory = new Dictionary<string, List<Book>>();

        private Books() {
            CreateBookDict();
        }

        public static Books Instance { get { return _instance; } }

        public Dictionary<string, Book> GetBooks()
        {
            return _books;
        }

        public Dictionary<string, List<Book>> getBookCategories()
        {
            return _booksCategory;
        }

        private void CreateBookDict()
        {
            // Setup all the categories
            List<Book> booksAdventure = new List<Book>();
            List<Book> booksFantasy = new List<Book>();
            List<Book> booksMystery = new List<Book>();
            List<Book> booksCookbook = new List<Book>();
            List<Book> booksMotivation = new List<Book>();
            List<Book> booksHistory = new List<Book>();

            // Add Authors here

            // Adventure Authors
            Author rickRiordan = new Author("Rick Riordan");
            Author julesVerne = new Author("Jules Verne");

            //History Authors
            Author arnoldToynbee = new Author("Arnold Toynbee");
            Author EPThompson = new Author("E.P. Thompson");

            //Motivation Authors
            Author victorEFankl = new Author("Victor E. Fankl");
            Author jenSincero = new Author("Jen Sincero");

            //Cookbook Authors
            Author ixtaBelfrage = new Author("Ixta Belfrage");
            Author tabithaBrown = new Author("Tabitha Brown");

            //Mystery Authors
            Author louisePenny = new Author("Louise Penny");
            Author nicholasBlake = new Author("Nicholas Blake");

            //Fantasy Authors
            Author georgeMartin = new Author("George R. R. Martin");
            Author patrickRothfuss = new Author("Patrick Rothfuss");

            // Add books here

            //Adventure Books--------------------------
            // Titan's Curse
            Dictionary<string, bool> titanFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book titanCurse = new Book(rickRiordan, new string[2] { "adventure", "fantasy" }, titanFormats, "/Book covers/the-titans-curse.jpg", 4.9f)
                .SetTitle("The Titan's Curse")
                .SetDescription("");
            _books.Add("The Titan's Curse".ToLower(), titanCurse);
            booksAdventure.Add(titanCurse);
            booksFantasy.Add(titanCurse);

            // The Lightning Thief
            Dictionary<string, bool> lightningThiefFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book lightningThief = new Book(rickRiordan, new string[2] { "adventure", "fantasy" }, lightningThiefFormats, "/Book covers/lightningThief.jpg", 4.9f)
                .SetTitle("The Lightning Thief")
                .SetDescription("Percy Jackson is a good kid, but he can't seem to focus on his schoolwork or control his temper. And lately, being away at boarding school is only getting worse - Percy could have sworn his pre-algebra teacher turned into a monster and tried to kill him. When Percy's mom finds out, she knows it's time that he knew the truth about where he came from, and that he go to the one place he'll be safe. She sends Percy to Camp Half Blood, a summer camp for demigods (on Long Island), where he learns that the father he never knew is Poseidon, God of the Sea. Soon a mystery unfolds and together with his friends—one a satyr and the other the demigod daughter of Athena - Percy sets out on a quest across the United States to reach the gates of the Underworld (located in a recording studio in Hollywood) and prevent a catastrophic war between the gods.");
            _books.Add("The Lightning Thief".ToLower(), lightningThief);
            booksAdventure.Add(lightningThief);
            booksFantasy.Add(lightningThief);

            // Daughter of the Deep
            Dictionary<string, bool> daughterOfDeepFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book daughterOfDeep = new Book(rickRiordan, new string[1] { "adventure" }, daughterOfDeepFormats, "/Book covers/daughterOfDeep.jpg", 4.9f)
                .SetTitle("Daughter of the Deep")
                .SetDescription("Ana Dakkar is a freshman at Harding-Pencroft Academy, a five-year high school that graduates the best marine scientists, naval warriors, navigators, and underwater explorers in the world. Ana's parents died while on a scientific expedition two years ago, and the only family she's got left is her older brother, Dev, also a student at HP. Ana's freshman year culminates with the class's weekend trial at sea, the details of which have been kept secret. She only hopes she has what it'll take to succeed. All her worries are blown out of the water when, on the bus ride to the ship, Ana and her schoolmates witness a terrible tragedy that will change the trajectory of their lives.");
            _books.Add("Daughter of the Deep".ToLower(), daughterOfDeep);
            booksAdventure.Add(daughterOfDeep);

            //Around the World in Eighty Days
            Dictionary<string, bool> aroundWorldEightyDaysFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book aroundWorldEightyDays = new Book(julesVerne, new string[1] { "adventure" }, aroundWorldEightyDaysFormats, "/Book covers/aroundWorldEightyDays.jpg", 4.9f)
                .SetTitle("Around the World in Eighty Days")
                .SetDescription("One night in the reform club, Phileas Fogg bets his companions that he can travel across the globe in just eighty days. Breaking the well-established routine of his daily life, he immediately sets off for Dover with his astonished valet Passepartout. Passing through exotic lands and dangerous locations, they seize whatever transportation is at hand—whether train or elephant—overcoming set-backs and always racing against the clock. ");
            _books.Add("Around the World in Eighty Days".ToLower(), aroundWorldEightyDays);
            booksAdventure.Add(aroundWorldEightyDays);

            // Journey to the Center of the Earth
            Dictionary<string, bool> journeyCenterEarthFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book journeyCenterEarth = new Book(julesVerne, new string[1] { "adventure"}, journeyCenterEarthFormats, "/Book covers/journeyCenterEarth.jpg", 4.9f)
                .SetTitle("Journey to the Center of the Earth")
                .SetDescription("An adventurous geology professor chances upon a manuscript in which a 16th-century explorer claims to have found a route to the earth's core. Professor Lidenbrock can't resist the opportunity to investigate, and with his nephew Axel, he sets off across Iceland in the company of Hans Bjelke, a native guide.");
            _books.Add("Journey to the Center of the Earth".ToLower(), journeyCenterEarth);
            booksAdventure.Add(journeyCenterEarth);

            //Adventure Books END---------------------

            //History Books ---------------------------

            // A study of history
            Dictionary<string, bool> studyOfHistoryFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", true }
            };
            Book studyOfHistory = new Book(arnoldToynbee, new string[1] { "history" }, studyOfHistoryFormats, "/Book covers/a-study-of-history.jpg", 4.9f)
                .SetTitle("A Study of History")
                .SetDescription("Arnold Toynbee's A Study of History is his magnum opus. In it he analyses the rise and fall of all 26 of the great world civilizations; whereas, previous historians had mainly concentrated on the West");
            _books.Add("A Study of History".ToLower(),studyOfHistory);
            booksHistory.Add(studyOfHistory);

            // Civilization On Trial
            Dictionary<string, bool> civOnTrialFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", true }
            };
            Book civOnTrial = new Book(arnoldToynbee, new string[1] { "history" }, civOnTrialFormats, "/Book covers/civOnTrial.jpg", 4.9f)
                .SetTitle("Civilization on Trial")
                .SetDescription("Toynbee predicts that our secular Western Civilization, although headed for destruction, will first bring about the political and cultural unification of mankind. Unlike our own materialistic culture, the coming world-embracing civilization will be essentially religious.");
            _books.Add("Civilization on Trial".ToLower(), civOnTrial);
            booksHistory.Add(civOnTrial);

            // Choose Life
            Dictionary<string, bool> chooseLifeFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", true }
            };
            Book chooseLife = new Book(arnoldToynbee, new string[1] { "history" }, chooseLifeFormats, "/Book covers/chooseLife.jpg", 4.9f)
                .SetTitle("Choose Life")
                .SetDescription("For over two years, historian Arnold J. Toynbee and religious leader Daisaku Ikeda exchanged views on a wide range of topics, probing for answers to the urgent as well as the perennial questions that confront humanity’s existence. From the personal to the international and the political to the philosophical, every sphere of human nature and interaction was vigorously discussed by these two men, who, though of different cultures and traditions, shared the same commitment to the value of human life and the biosphere that sustains it.\r\n\r\nWhile their exchanges occurred in London in the 1970s, the insights they offer are timeless and relevant, providing both a panorama and a vital framework for understanding the choices and interlinked issues facing humanity in the 21st century.");
            _books.Add("Choose Life".ToLower(), chooseLife);
            booksHistory.Add(chooseLife);

            //Making of English Working Class
            Dictionary<string, bool> workingClassFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book workingClass = new Book(EPThompson, new string[1] { "history" }, workingClassFormats, "/Book covers/workingClass.jpg", 4.9f)
                .SetTitle("The Making of the English Working Class")
                .SetDescription("This book transformed our understanding of English social history. Thompson revealed how working class people were not merely victims of history, moved by powerful forces outside of themselves, but were also active in creating their own culture and future, during the degradation of the industrial revolution.");
            _books.Add("The Making of the English Working Class".ToLower(), workingClass);
            booksHistory.Add(workingClass);

            //Customs in Common
            Dictionary<string, bool> customsInCommonFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book customsInCommon = new Book(EPThompson, new string[1] { "history" }, customsInCommonFormats, "/Book covers/customsInCommon.jpg", 4.9f)
                .SetTitle("Customs in Common")
                .SetDescription("Here, at last, is Customs in Common, the remarkable sequel to E.P. Thompson’s influential, landmark volume of social history, The Making of the English Working Class. The product of years of research and debate, Customs in Common describes the complex culture from which working class institutions emerged in England—a panoply of traditions and customs that the new working class fought to preserve well into Victorian times.");
            _books.Add("Customs in Common".ToLower(), customsInCommon);
            booksHistory.Add(customsInCommon);

            //History Books END---------------------

            //Motivation Books

            // Man’s Search for Meaning
            Dictionary<string, bool> manMeaningFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book manMeaning = new Book(victorEFankl, new string[1] { "motivation" }, manMeaningFormats, "/Book covers/manMeaning.jpg", 4.9f)
                .SetTitle("Man's Search for Meaning")
                .SetDescription("Psychiatrist Viktor Frankl’s discusses in-depth his experience with living in Nazi death camps and describes the lessons it taught him about spiritual survival. Frankl puts forth a convincing argument that avoiding suffering isn’t realistic. However, through choosing how we cope with that suffering and the meaning we ascribe to it, we retain the ability to move forward with renewed purpose.");
            _books.Add("Man's Search for Meaning".ToLower(), manMeaning);
            booksMotivation.Add(manMeaning);

            // The Will to Meaning
            Dictionary<string, bool> willMeaningFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book willMeaning = new Book(victorEFankl, new string[1] { "motivation" }, willMeaningFormats, "/Book covers/willMeaning.jpg", 4.9f)
                .SetTitle("The Will to Meaning")
                .SetDescription("Frankl posits that the will to meaning, or the desire to find and create meaning in one's life, is the primary motivating force in a person's life because it is the one thing for which a person is willing to live and die.");
            _books.Add("The Will to Meaning".ToLower(), willMeaning);
            booksMotivation.Add(willMeaning);

            // Yes to Life: In Spite of Everything
            Dictionary<string, bool> yesLifeFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book yesLife = new Book(victorEFankl, new string[1] { "motivation" }, yesLifeFormats, "/Book covers/yesLife.jpg", 4.9f)
                .SetTitle("Yes to Life: In Spite of Everything")
                .SetDescription("This is the text of a series of three lectures given in 1946 by Viktor Frankl, the Auschwitz survivor famous for his book Man's Search for Meaning about his philosophy of finding a sense of purpose and meaning even in the direst of circumstances a human being can live through.");
            _books.Add("Yes to Life: In Spite of Everything".ToLower(), yesLife);
            booksMotivation.Add(yesLife);

            // You Are a Badass: How to Stop Doubting Your Greatness and Start Living an Awesome Life
            Dictionary<string, bool> youBadassFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book youBadass = new Book(jenSincero, new string[1] { "motivation" }, youBadassFormats, "/Book covers/youBadass.jpg", 4.9f)
                .SetTitle("You Are a Badass: How to Stop Doubting Your Greatness and Start Living an Awesome Life")
                .SetDescription("Of all the motivational books out there, this is a must-read for those who are into life design.Through this book, Jen provides her readers with simple exercises to help people identify their self-limiting beliefs, attitudes, and habits. She provides some great advice and does so in a humorous way to truly captivate her audience and motivate them to begin achieving the success they want from their lives.");
            _books.Add("You Are a Badass: How to Stop Doubting Your Greatness and Start Living an Awesome Life".ToLower(), youBadass);
            booksMotivation.Add(youBadass);

            // Badass Habits: Cultivate the Awareness, Boundaries, and Daily Upgrades You Need to Make Them Stick
            Dictionary<string, bool> badassHabitsFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book badassHabits = new Book(jenSincero, new string[1] { "motivation" }, badassHabitsFormats, "/Book covers/badassHabits.jpg", 4.9f)
                .SetTitle("Badass Habits: Cultivate the Awareness, Boundaries, and Daily Upgrades You Need to Make Them Stick")
                .SetDescription("Badass Habits is a eureka-sparking, easy-to-digest look at how our habits make us who we are, from the measly moments that happen in private to the resolutions we loudly broadcast (and, erm, often don't keep) on social media. Habit busting and building goes way beyond becoming a dedicated flosser or never showing up late again--our habits reveal our unmet desires, the gaps in our boundaries, our level of self-awareness, and our unconscious beliefs and fears. Badass Habits features Jen's trademark hilarious voice and offers a much-needed fresh take on the conventional wisdom and science that shape the optimism (or pessimism?) around the age-old topic of habits. The book includes enlightening interviews with people who've successfully strengthened their discipline backbones, new perspective on how to train our brains to become our best selves, and offers a simple, 21 day, step-by-step guide for ditching habits that don't serve us and developing the habits we deem most important. Habits shouldn't be impossible to reset--and with healthy boundaries, knowledge of--and permission to go after--our desires, and an easy to implement plan of action, we can make any new goal a joyful habit.");
            _books.Add("Badass Habits: Cultivate the Awareness, Boundaries, and Daily Upgrades You Need to Make Them Stick".ToLower(), badassHabits);
            booksMotivation.Add(badassHabits);

            //Motivation Books END---------------------

            //Cookbooks---------------------------------

            //Cooking from the Spirit: Easy, Delicious, and Joyful Plant-Based Inspirations
            Dictionary<string, bool> cookFromSpiritFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book cookFromSpirit = new Book(tabithaBrown, new string[1] { "cookbook" }, cookFromSpiritFormats, "/Book covers/cookFromSpirit.jpg", 4.9f)
                .SetTitle("Cooking from the Spirit: Easy, Delicious, and Joyful Plant-Based Inspirations")
                .SetDescription("Tabitha Brown, the #1 New York Times bestselling author of Feeding the Soul, presents her first cookbook—full of easy, family-friendly vegan recipes and stories from the spirit, inspired by her health journey and love of delicious food.Sometimes people say to Tabitha Brown, “I’ve never eaten vegan before.” As Tab says, “Have you ever eaten an apple?” After living with a terrible undiagnosed illness for more than a year and a half, Tab was willing to try anything to stop the pain. Inspired by the documentary What the Health, she tried a thirty-day vegan challenge—and never looked back. Wanting to inspire others to make changes that might improve their own lives, she started sharing her favorite plant-based recipes in her signature warm voice with thousands, and now millions, of online fans.");
            _books.Add("Cooking from the Spirit: Easy, Delicious, and Joyful Plant-Based Inspirations".ToLower(), cookFromSpirit);
            booksCookbook.Add(cookFromSpirit);

            //Feeding the Soul (Because It's My Business): Finding Our Way to Joy, Love, and Freedom
            Dictionary<string, bool> feedTheSoulFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book feedTheSoul = new Book(tabithaBrown, new string[1] { "cookbook" }, feedTheSoulFormats, "/Book covers/feedTheSoul.jpg", 4.9f)
                .SetTitle("Feeding the Soul (Because It's My Business): Finding Our Way to Joy, Love, and Freedom")
                .SetDescription("Before Tabitha Brown was one of the most popular personalities in the world, sharing her delicious vegan home cooking and compassionate wisdom with millions of followers across social media, she was an aspiring actress who in 2016 began struggling with undiagnosed chronic autoimmune pain. Her condition made her believe she wouldn’t live to see forty--until she started listening to what her soul and her body truly needed. Now, in this life-changing book, Tabitha shares the wisdom she gained from her own journey, showing readers how to make a life for themselves that is rooted in nonjudgmental kindness and love, both for themselves and for others.");
            _books.Add("Feeding the Soul (Because It's My Business): Finding Our Way to Joy, Love, and Freedom".ToLower(), feedTheSoul);
            booksCookbook.Add(feedTheSoul);

            //Seen, Loved and Heard: A Guided Journal for Feeding the Soul
            Dictionary<string, bool> seenLovedHeardFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book seenLovedHeard = new Book(tabithaBrown, new string[1] { "cookbook" }, seenLovedHeardFormats, "/Book covers/seenLovedHeard.jpg", 4.9f)
                .SetTitle("Seen, Loved and Heard: A Guided Journal for Feeding the Soul")
                .SetDescription("In her beloved book Feeding the Soul, Tabitha Brown made readers feel seen, loved, and heard, sharing the knowledge she's gained from her own journey in life. Now, in this gorgeous keepsake journal, Tab invites readers to think more deeply about their own life paths, and how to live in more love and happiness. Readers will be drawn in to write on each creatively illustrated, uplifting page, with:\r\n\r\nDozens of thought-provoking writing prompts in Tabitha's encouraging voiceCharming and colorful illustrationsMotivational and inspirational \"Tabisms\"Space for readers to write in their own stories, hopes, and dreams--and make the journal their own! This soul-healing journal encourages readers to take some time to reflect on their own sources of joy and hope, spirituality, self-image, and peace, and to look back on when they want to appreciate how far they've come and what insights they've gained in their own journeys");
            _books.Add("Seen, Loved and Heard: A Guided Journal for Feeding the Soul".ToLower(), seenLovedHeard);
            booksCookbook.Add(seenLovedHeard);

            //Ottolenghi Flavor: A Cookbook
            Dictionary<string, bool> ottoLenghiFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book ottoLenghi = new Book(ixtaBelfrage, new string[1] { "cookbook" }, ottoLenghiFormats, "/Book covers/ottoLenghi.jpg", 4.9f)
                .SetTitle("Ottolenghi Flavor: A Cookbook")
                .SetDescription("Level up your vegetables. In this groundbreaking cookbook, Yotam Ottolenghi and Ixta Belfrage offer a next-level approach to vegetables that breaks down the fundamentals of cooking into three key elements: process, pairing, and produce. For process, Yotam and Ixta show how easy techniques such as charring and infusing can change the way you think about cooking. Discover how to unlock new depths of flavor by pairing vegetables with sweetness, fat, acidity, or chile heat, and learn to identify the produce that has the innate ability to make dishes shine.");
            _books.Add("Ottolenghi Flavor: A Cookbook".ToLower(), ottoLenghi);
            booksCookbook.Add(ottoLenghi);

            //Mezcla: Recipes to Excite
            Dictionary<string, bool> mezclaFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book mezcla = new Book(ixtaBelfrage, new string[1] { "cookbook" }, mezclaFormats, "/Book covers/mezcla.jpg", 4.9f)
                .SetTitle("Mezcla: Recipes to Excite")
                .SetDescription("MEZCLA means mix, blend, or fusion in Spanish, and in her first solo cookbook, Ixta Belfrage—loved for her inventive ingredient combinations—shares her favorite mezcla of flavors. Helpfully divided into quick recipes (for when you need something great on the table, fast) and longer recipes (for when you have time to slow down and savor the process), here are one hundred bold, impactful recipes inspired by Italy, Brazil, Mexico, and beyond. ");
            _books.Add("Mezcla: Recipes to Excite".ToLower(), mezcla);
            booksCookbook.Add(mezcla);

            //Cooking Books END---------------------

            //Mystery Books ---------------------------

            // Still Life: A Chief Inspector Gamache Novel
            Dictionary<string, bool> stillLifeFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book stillLife = new Book(louisePenny, new string[1] { "mystery" }, stillLifeFormats, "/Book covers/stillLife.jpg", 4.9f)
                .SetTitle("Still Life: A Chief Inspector Gamache Novel")
                .SetDescription("The discovery of a dead body in the woods on Thanksgiving Weekend brings Chief Inspector Armand Gamache and his colleagues from the Surete du Quebec to a small village in the Eastern Townships. Gamache cannot understand why anyone would want to deliberately kill well-loved artist Jane Neal, especially any of the residents of Three Pines - a place so free from crime it doesn't even have its own police force.");
            _books.Add("Still Life: A Chief Inspector Gamache Novel".ToLower(), stillLife);
            booksMystery.Add(stillLife);

            // A Fatal Grace
            Dictionary<string, bool> fatalGraceFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book fatalGrace = new Book(louisePenny, new string[1] { "mystery" }, fatalGraceFormats, "/Book covers/fatalGrace.jpg", 4.9f)
                .SetTitle("A Fatal Grace")
                .SetDescription("Welcome to winter in Three Pines, a picturesque village in Quebec, where the villagers are preparing for a traditional country Christmas, and someone is preparing for murder.");
            _books.Add("A Fatal Grace".ToLower(), fatalGrace);
            booksMystery.Add(fatalGrace);

            // A Rule Against Murder
            Dictionary<string, bool> ruleAgainstMurderFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book ruleAgainstMurder = new Book(louisePenny, new string[1] { "mystery" }, ruleAgainstMurderFormats, "/Book covers/ruleAgainstMurder.jpg", 4.9f)
                .SetTitle("A Rule Against Murder")
                .SetDescription("It is the height of summer, and Armand and Reine-Marie Gamache are celebrating their wedding anniversary at Manoir Bellechasse, an isolated, luxurious inn not far from the village of Three Pines. But they're not alone. The Finney family—rich, cultured, and respectable—has also arrived for a celebration of their own.");
            _books.Add("A Rule Against Murder".ToLower(), ruleAgainstMurder);
            booksMystery.Add(ruleAgainstMurder);

            // The Beast Must Die
            Dictionary<string, bool> beastMustDieFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book beastMustDie = new Book(nicholasBlake, new string[1] { "mystery" }, beastMustDieFormats, "/Book covers/beastMustDie.jpg", 4.9f)
                .SetTitle("The Beast Must Die")
                .SetDescription("Frank Cairnes, a popular detective writer who now embarks on a real-life crime of his own, determined to hunt down the runaway motorist who killed his small son Martin.");
            _books.Add("The Beast Must Die".ToLower(), beastMustDie);
            booksMystery.Add(beastMustDie);

            // A Question of Proof
            Dictionary<string, bool> questionOfProofFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book questionOfProof = new Book(nicholasBlake, new string[1] { "mystery" }, questionOfProofFormats, "/Book covers/questionOfProof.jpg", 4.9f)
                .SetTitle("A Question of Proof")
                .SetDescription("The faculty and student body at Sudeley are shocked but scarcely saddened when the headmaster’s obnoxious nephew, Algernon Wyvern-Wemyss, is found dead in a haystack on Sports Day.");
            _books.Add("A Question of Proof".ToLower(), questionOfProof);
            booksMystery.Add(questionOfProof);

            //Mystery Books END---------------------

            //Fantasy Books----------------------------

            // A Game of Thrones
            Dictionary<string, bool> gameOfThronesFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book gameOfThrones = new Book(georgeMartin, new string[1] { "fantasy" }, gameOfThronesFormats, "/Book covers/gameOfThrones.jpg", 4.9f)
                .SetTitle("A Game of Thrones")
                .SetDescription("Long ago, in a time forgotten, a preternatural event threw the seasons out of balance. In a land where summers can last decades and winters a lifetime, trouble is brewing. The cold is returning, and in the frozen wastes to the north of Winterfell, sinister forces are massing beyond the kingdom’s protective Wall. To the south, the king’s powers are failing—his most trusted adviser dead under mysterious circumstances and his enemies emerging from the shadows of the throne. At the center of the conflict lie the Starks of Winterfell, a family as harsh and unyielding as the frozen land they were born to. Now Lord Eddard Stark is reluctantly summoned to serve as the king’s new Hand, an appointment that threatens to sunder not only his family but the kingdom itself.");
            _books.Add("A Game of Thrones".ToLower(), gameOfThrones);
            booksFantasy.Add(gameOfThrones);

            // Fire & Blood
            Dictionary<string, bool> fireAndBloodFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book fireAndBlood = new Book(georgeMartin, new string[1] { "fantasy" }, fireAndBloodFormats, "/Book covers/fireAndBlood.jpg", 4.9f)
                .SetTitle("Fire & Blood")
                .SetDescription("With all the fire and fury fans have come to expect from internationally bestselling author George R. R. Martin, this is the first volume of the definitive two-part history of the Targaryens in Westeros.");
            _books.Add("Fire & Bloods".ToLower(), fireAndBlood);
            booksFantasy.Add(fireAndBlood);

            //A Dance with Dragons
            Dictionary<string, bool> danceOfDragonsFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book danceOfDragons = new Book(georgeMartin, new string[1] { "fantasy" }, danceOfDragonsFormats, "/Book covers/danceOfDragons.jpg", 4.9f)
                .SetTitle("A Dance with Dragons")
                .SetDescription("In the aftermath of a colossal battle, the future of the Seven Kingdoms hangs in the balance—beset by newly emerging threats from every direction. In the east, Daenerys Targaryen, the last scion of House Targaryen, rules with her three dragons as queen of a city built on dust and death. But Daenerys has thousands of enemies, and many have set out to find her. As they gather, one young man embarks upon his own quest for the queen, with an entirely different goal in mind.");
            _books.Add("A Dance with Dragons".ToLower(), danceOfDragons);
            booksFantasy.Add(danceOfDragons);

            // The Name of the Wind
            Dictionary<string, bool> nameOfWindFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book nameOfWind = new Book(patrickRothfuss, new string[1] { "fantasy" }, nameOfWindFormats, "/Book covers/nameOfWind.jpg", 4.9f)
                .SetTitle("The Name of the Wind")
                .SetDescription("Told in Kvothe's own voice, this is the tale of the magically gifted young man who grows to be the most notorious wizard his world has ever seen.The intimate narrative of his childhood in a troupe of traveling players, his years spent as a near-feral orphan in a crime-ridden city, his daringly brazen yet successful bid to enter a legendary school of magic, and his life as a fugitive after the murder of a king form a gripping coming-of-age story unrivaled in recent literature.");
            _books.Add("The Name of the Wind".ToLower(), nameOfWind);
            booksFantasy.Add(nameOfWind);

            //The Wise Man's Fear
            Dictionary<string, bool> wiseManFearFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book wiseManFear = new Book(patrickRothfuss, new string[1] { "fantasy" }, wiseManFearFormats, "/Book covers/wiseManFear.jpg", 4.9f)
                .SetTitle("The Wise Man's Fear")
                .SetDescription("My name is Kvothe.\r\nI have stolen princesses back from sleeping barrow kings. I burned down the town of Trebon. I have spent the night with Felurian and left with both my sanity and my life. I was expelled from the University at a younger age than most people are allowed in. I tread paths by moonlight that others fear to speak of during day. I have talked to Gods, loved women, and written songs that make the minstrels weep.\r\nYou may have heard of me.");
            _books.Add("TThe Wise Man's Fear".ToLower(), wiseManFear);
            booksFantasy.Add(wiseManFear);

            //Fantasy Books END---------------------

            _booksCategory.Add("adventure", booksAdventure);
            _booksCategory.Add("fantasy", booksFantasy);
            _booksCategory.Add("mystery", booksMystery);
            _booksCategory.Add("motivation", booksMotivation);
            _booksCategory.Add("cookbook", booksCookbook);
            _booksCategory.Add("history", booksHistory);

        }
    }
}
