using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int i;
            // Get the player's name and description from the user, and use these details to create a Player object.
            Player _player;
            Console.WriteLine("Please enter the player's name: ");
            string player_name = Console.ReadLine();
            Console.WriteLine("Please enter the player's description: ");
            string player_description = Console.ReadLine();
            _player = new Player(player_name, player_description);

            // Create two items and add them to the the player's inventory
            Item map = new Item(new string[] { "map" }, "Map", "This is the map");
            Item stick = new Item(new string[] { "stick" }, "Stick", "This is the stick");
            Item mushroom = new Item(new string[] { "mushroom" }, "Mushroom", "This is the mushroom");
            Item sword = new Item(new string[] { "sword" }, "Sword", "This is the sword");
            Item armor = new Item(new string[] { "armor" }, "Sword", "This is the armor");
            Item gem = new Item(new string[] { "gem" }, "Gem", "This is the Gem");
            Item stone = new Item(new string[] { "stone" }, "Stone", "This is the stone");
            Item egg = new Item(new string[] { "egg" }, "Egg", "This is the egg");
            Item seed = new Item(new string[] { "seed" }, "Seed", "This is the seed");
            Item water = new Item(new string[] { "water" }, "water", "This is the water");
            Item ruby = new Item(new string[] { "ruby" }, "Ruby", "This is the ruby");
            Item diamond = new Item(new string[] { "diamond" }, "Diamond", "This is the diamond");
            Item fish = new Item(new string[] { "fish" }, "Fish", "This is the fish");
            Item meat = new Item(new string[] { "meat" }, "Meat", "This is the meat");
            Item fruit = new Item(new string[] { "fruit" }, "Fruit", "This is the fruit");
            Item shield = new Item(new string[] { "shield" }, "Shield", "This is the shield");
            Item shoe = new Item(new string[] { "shoe" }, "Shoe", "This is the shoe");
            Item wine = new Item(new string[] { "wine" }, "Wine", "This is the wine");
            Item coffee = new Item(new string[] { "coffee" }, "Coffee", "This is the coffee");
            Item knife = new Item(new string[] { "knife" }, "Knife", "This is the knife");
            Item gold = new Item(new string[] { "gold" }, "Gold", "This item is in the Player's bag");

            _player.Inventory.Put(map);
            _player.Inventory.Put(stick);
            _player.Inventory.Put(sword);
            _player.Inventory.Put(mushroom);
            _player.Inventory.Put(armor);

            // Create a bag and add it to the player's inventory
            Bag _bag = new Bag(new string[] { "playerBag", "bag" }, "Player's bag", "This is the bag of the player");
            _player.Inventory.Put(_bag);

            // Create another item and add it to the bag

            _bag.Inventory.Put(meat);
            _bag.Inventory.Put(knife);
            _bag.Inventory.Put(gold);

            //create location for player
            Location Lake = new Location("Lake", "You're at Lake");
            Location Jungle = new Location("Jungle", "You're at Jungle");
            Location Home = new Location("Home", "You're at Home");
            Location Museum = new Location("Musium", "You're at Museum");
            Location Cinema = new Location("Cinema", "You're at Cinema");
            Location Market = new Location("Market", "You're at Market");
            Location Saloon = new Location("Saloon", "You're at Saloon");
            Location Restaurant = new Location("Restaurant", "You're at Restaurant");
            Location CoffeeShop = new Location("CoffeeShop", "You're at CoffeeShop");

            //Player default location
            _player.Location = Home;

            //Path from Home
            Path[] home = new Path[8];
            home[0] = new Path(new string[] { "north", "up" }, "Home", "Go form Home to Jungle", _player.Location, Jungle);
            home[1] = new Path(new string[] { "south", "down" }, "Home", "Go form Home to Lake", _player.Location, Lake);
            home[2] = new Path(new string[] { "east" }, "Home", "Go form Home to CoffeeShop", _player.Location, CoffeeShop);
            home[3] = new Path(new string[] { "west" }, "Home", "Go form Home to Restaurant", _player.Location, Restaurant);
            home[4] = new Path(new string[] { "northeast" }, "Home", "Go form Home to Museum", _player.Location, Museum);
            home[5] = new Path(new string[] { "northwest" }, "Home", "Go form Home to Cinema", _player.Location, Cinema);
            home[6] = new Path(new string[] { "southeast" }, "Home", "Go form Home to Market", _player.Location, Market);
            home[7] = new Path(new string[] { "southwest" }, "Home", "Go form Home to Saloon", _player.Location, Saloon);
            for (i = 0; i < home.Length; i++)
            {
                Home.AddPath(home[i]);
            }

            //Path from Jungle
            Path[] jungle = new Path[5];
            jungle[0] = new Path(new string[] { "south", "down" }, "Jungle", "Go form Jungle to Home", _player.Location, Home);
            jungle[1] = new Path(new string[] { "east"}, "Jungle", "Go form Jungle to Cinema", _player.Location, Cinema);
            jungle[2] = new Path(new string[] { "west"}, "Jungle", "Go form Jungle to Museum", _player.Location, Museum);
            jungle[3] = new Path(new string[] { "southeast"}, "Jungle", "Go form Jungle to CoffeeShop", _player.Location, CoffeeShop);
            jungle[4] = new Path(new string[] { "southwest"}, "Jungle", "Go form Jungle to Restaurant", _player.Location, Restaurant);
            for (i = 0; i < jungle.Length; i++)
            {
                Jungle.AddPath(jungle[i]);
            }

            //Path from Lake
            Path[] lake = new Path[5];
            lake[0] = new Path(new string[] { "north", "up" }, "Lake", "Go form Lake to Home", _player.Location, Home);
            lake[1] = new Path(new string[] { "east" }, "Lake", "Go form Lake to Market", _player.Location, Market);
            lake[2] = new Path(new string[] { "west" }, "Lake", "Go form Lake to Saloon", _player.Location, Saloon);
            lake[3] = new Path(new string[] { "northeast" }, "Lake", "Go form Lake to CoffeeShop", _player.Location, CoffeeShop);
            lake[4] = new Path(new string[] { "northwest" }, "Lake", "Go form Lake to Restaurant", _player.Location, Restaurant);
            for (i = 0; i < lake.Length; i++)
            {
                Lake.AddPath(lake[i]);
            }

            //Path from CoffeeShop
            Path[] coffeeshop = new Path[5];
            coffeeshop[0] = new Path(new string[] { "north", "up" }, "CoffeeShop", "Go form CoffeeShop to Cinema", _player.Location, Cinema);
            coffeeshop[1] = new Path(new string[] { "south", "down" }, "CoffeeShop", "Go form CoffeeShop to Market", _player.Location, Market);
            coffeeshop[2] = new Path(new string[] { "west"}, "CoffeeShop", "Go form CoffeeShop to Home", _player.Location, Home);
            coffeeshop[3] = new Path(new string[] { "northwest"}, "CoffeeShop", "Go form CoffeeShop to Jungle", _player.Location, Jungle);
            coffeeshop[4] = new Path(new string[] { "southwest"}, "CoffeeShop", "Go form CoffeeShop to Lake", _player.Location, Lake);
            for (i = 0; i < coffeeshop.Length; i++)
            {
                CoffeeShop.AddPath(coffeeshop[i]);
            }

            //Path from Restaurant
            Path[] restaurant = new Path[5];
            restaurant[0] = new Path(new string[] { "north", "up" }, "Restaurant", "Go form Restaurant to Museum", _player.Location, Museum);
            restaurant[1] = new Path(new string[] { "south", "down" }, "Restaurant", "Go form Restaurant to Saloon", _player.Location, Saloon);
            restaurant[2] = new Path(new string[] { "east"}, "Restaurant", "Go form Restaurant to Home", _player.Location, Home);
            restaurant[3] = new Path(new string[] { "northeast"}, "Restaurant", "Go form Restaurant to Jungle", _player.Location, Jungle);
            restaurant[4] = new Path(new string[] { "southeast"}, "Restaurant", "Go form Restaurant to Lake", _player.Location, Lake);
            for (i = 0; i < restaurant.Length; i++)
            {
                Restaurant.AddPath(restaurant[i]);
            }

            //Path from Cinema
            Path[] cinema = new Path[3];
            cinema[0] = new Path(new string[] { "south", "down" }, "Cinema", "Go form Cinema to CoffeeShop", _player.Location, CoffeeShop);
            cinema[1] = new Path(new string[] { "west"}, "Cinema", "Go form Cinema to Jungle", _player.Location, Jungle);
            cinema[2] = new Path(new string[] { "southwest", "down" }, "Cinema", "Go form Cinema to Home", _player.Location, Home);
            for (i = 0; i < cinema.Length; i++)
            {
                Cinema.AddPath(cinema[i]);
            }

            //Path from Museum
            Path[] museum = new Path[3];
            museum[0] = new Path(new string[] { "south", "down" }, "Museum", "Go form Museum to Restaurant", _player.Location, Restaurant);
            museum[1] = new Path(new string[] { "east"}, "Museum", "Go form Museum to Jungle", _player.Location, Jungle);
            museum[2] = new Path(new string[] { "southeast"}, "Museum", "Go form Museum to Home", _player.Location, Home);
            for (i = 0; i < museum.Length; i++)
            {
                Museum.AddPath(museum[i]);
            }

            //Path from Market
            Path[] market = new Path[3];
            market[0] = new Path(new string[] { "north", "up"}, "Market", "Go form Market to CoffeeShop", _player.Location, CoffeeShop);
            market[1] = new Path(new string[] { "west"}, "Market", "Go form Market to Lake", _player.Location, Lake);
            market[2] = new Path(new string[] { "northwest"}, "Market", "Go form Market to Home", _player.Location, Home);
            for (i = 0; i < market.Length; i++)
            {
                Market.AddPath(market[i]);
            }


            //Path from Saloon
            Path[] saloon = new Path[3];
            saloon[0] = new Path(new string[] { "north", "up" }, "Saloon", "Go form Saloon to Restaurant", _player.Location, Restaurant);
            saloon[0] = new Path(new string[] { "east"}, "Saloon", "Go form Saloon to Lake", _player.Location, Lake);
            saloon[0] = new Path(new string[] { "northeast"}, "Saloon", "Go form Saloon to Home", _player.Location, Home);
            for (i = 0; i < saloon.Length; i++)
            {
                Saloon.AddPath(saloon[i]);
            }



            Home.Inventory.Put(gem);
            Home.Inventory.Put(diamond);
            Home.Inventory.Put(shield);
            Jungle.Inventory.Put(stone);
            Jungle.Inventory.Put(seed);
            Museum.Inventory.Put(shield);
            Museum.Inventory.Put(ruby);
            Restaurant.Inventory.Put(meat);
            Restaurant.Inventory.Put(water);
            Lake.Inventory.Put(fish);
            Lake.Inventory.Put(diamond);
            Market.Inventory.Put(meat);
            Market.Inventory.Put(fish);
            Saloon.Inventory.Put(water);
            Saloon.Inventory.Put(wine);
            Cinema.Inventory.Put(egg);
            Cinema.Inventory.Put(shoe);
            CoffeeShop.Inventory.Put(fruit);
            CoffeeShop.Inventory.Put(coffee);



            //Loop reading commands from the user, and getting the look command to execute them
            CommandProcessor _commandProcessor = new CommandProcessor();
            while (true)
            {
                Console.WriteLine("Write your command: ");
                string user_command = Console.ReadLine();
                string[] command_array = user_command.Split(' ');
                string output = _commandProcessor.Execute(_player, command_array);
                Console.WriteLine(output);
            }
        }
    }
}
