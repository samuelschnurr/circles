using Io.Schnurr.Circles.Shared.Enums;
using Io.Schnurr.Circles.Shared.Models;
using File = Io.Schnurr.Circles.Shared.Models.File;

namespace Io.Schnurr.Circles.Api.TestData;

internal static class TestAdvertisements
{
    internal static List<Advertisement> GetAdvertisements()
    {
        List<Advertisement> advertisements = new()
        {
            new Advertisement
            {
                Id = 1,
                Title = "Wooden Jewelry Box",
                Description = "Hey there, I'm Jane! Check out this lovely wooden jewelry box. It's perfect for keeping your precious jewelry safe and looking great. I'm selling it for $49.99. Drop me a message at jane.doe@schnurrio.invalid if you're interested!",
                Price = 49.99m,
                CreatedBy = "jane.doe@schnurrio.invalid",
                Condition = AdvertisementCondition.VeryGood,
                Image = new File { Name = "jewelrybox.jpg", Path = "/images/jewelrybox.jpg" },
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 7, 15),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 2,
                Title = "Custom Hand-Painted Portrait",
                Description = "I can turn your favorite photos into beautiful hand-painted portraits. They're truly one-of-a-kind pieces. Interested? Get in touch with me at max.due@schnurrio.invalid.",
                Price = 199.99m,
                CreatedBy = "max.due@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = new File { Name = "portrait.jpg", Path = "/images/portrait.jpg" },
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 6, 20),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 3,
                Title = "Pure Organic Honey",
                Description = "I've got some delicious organic honey straight from the hive. No funny stuff in it, just pure, natural sweetness.",
                Price = 14.99m,
                CreatedBy = "peter.corla@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = new File { Name = "honey.jpg", Path = "/images/honey.jpg" },
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 6, 10),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 4,
                Title = "Greeting Cards",
                Description = "Hey, I make personalized greeting cards! They're perfect for special occasions. Each card is a heartfelt message.",
                Price = 4.99m,
                CreatedBy = "tanja.maker@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = new File { Name = "greetingcards.jpg", Path = "/images/greetingcards.jpg" },
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 5, 30),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 5,
                Title = "Organic Garden Vegetables",
                Description = "Hello, I'm a gardener! I've got fresh, organic vegetables from my garden. They're healthy and delicious. Selling them for $2.99. Want some? Shoot me an email at franz.lustig@schnurrio.invalid!",
                Price = 2.99m,
                CreatedBy = "franz.lustig@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = new File { Name = "vegetables.jpg", Path = "/images/vegetables.jpg" },
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 5, 15),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 6,
                Title = "Stainless Steel Water Bottle",
                Description = "Selling a stainless steel water bottle. It's great for staying hydrated on the go.",
                Price = 19.99m,
                CreatedBy = "matthias.dorp@schnurrio.invalid",
                Condition = AdvertisementCondition.Good,
                Image = new File { Name = "waterbottle.jpg", Path = "/images/waterbottle.jpg" },
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 7, 5),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 7,
                Title = "Wireless Bluetooth Earbuds",
                Description = "Hi there! I'm selling wireless Bluetooth earbuds. They're perfect for music lovers. Great sound quality.",
                Price = 39.99m,
                CreatedBy = "jane.doe@schnurrio.invalid",
                Condition = AdvertisementCondition.VeryGood,
                Image = new File { Name = "earbuds.jpg", Path = "/images/earbuds.jpg" },
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 9, 25),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 8,
                Title = "Classic Leather Wallet",
                Description = "Hello, I've got a classic leather wallet for sale. It's genuine leather. It's a great accessory. Interested?",
                Price = 29.99m,
                CreatedBy = "karl.tenter@schnurrio.invalid",
                Condition = AdvertisementCondition.Acceptable,
                Image = new File { Name = "wallet.jpg", Path = "/images/wallet.jpg" },
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 1, 15),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 9,
                Title = "Ceramic Coffee Mug Set",
                Description = "Hey, I've got a set of ceramic coffee mugs for sale. There are four mugs in different colors. Perfect for coffee lovers!",
                Price = 24.99m,
                CreatedBy = "nico.baristata@schnurrio.invalid",
                Condition = AdvertisementCondition.Acceptable,
                Image = new File { Name = "mugs.jpg", Path = "/images/mugs.jpg" },
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 12, 5),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 10,
                Title = "Camping Tent for Two",
                Description = "Selling a camping tent for two. It's easy to set up and great for any weather.",
                Price = 79.99m,
                CreatedBy = "vald.korsko@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = new File { Name = "campingtent.jpg", Path = "/images/campingtent.jpg" },
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 5, 20),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 11,
                Title = "Sony 65-Inch 4K Ultra HD Smart LED TV",
                Description = "I'm selling a Sony 65-inch 4K Ultra HD Smart LED TV. It's awesome for movies and shows.",
                Price = 899.99m,
                CreatedBy = "jane.doe@schnurrio.invalid",
                Condition = AdvertisementCondition.VeryGood,
                Image = new File { Name = "sony_tv.jpg", Path = "/images/sony_tv.jpg" },
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 4, 10),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 12,
                Title = "Apple MacBook Pro 15-Inch Laptop",
                Description = "Hi, I'm selling an Apple MacBook Pro 15-inch laptop. It's got a powerful processor and a great display. Only $1899.99. Interested? Drop me a message at techguy@schnurrio.invalid!",
                Price = 1899.99m,
                CreatedBy = "steve.works@schnurrio.invalid",
                Condition = AdvertisementCondition.VeryGood,
                Image = new File { Name = "macbook_pro.jpg", Path = "/images/macbook_pro.jpg" },
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 1, 15),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 13,
                Title = "DJI Mavic Air 2 Drone",
                Description = "Hey, I'm selling a DJI Mavic Air 2 drone. It's great for capturing videos and photos from the sky. Only $799.99. Interested? Shoot me an email at droneguy@schnurrio.invalid!",
                Price = 799.99m,
                CreatedBy = "sam.strick@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = new File { Name = "mavic_air_2.jpg", Path = "/images/mavic_air_2.jpg" },
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 11, 25),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 14,
                Title = "Samsung Galaxy S22 Ultra Smartphone",
                Description = "Hi, I'm selling a Samsung Galaxy S22 Ultra smartphone. It's got a great camera and a beautiful display. Only $1099.99. Interested? Drop me a message at samsungguy@schnurrio.invalid!",
                Price = 1099.99m,
                CreatedBy = "cordula.blue@schnurrio.invalid",
                Condition = AdvertisementCondition.Good,
                Image = new File { Name = "samsung_s22.jpg", Path = "/images/samsung_s22.jpg" },
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 2, 10),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 15,
                Title = "Sony WH-1000XM4 Wireless Noise-Canceling Headphones",
                Description = "Hey there, I'm selling Sony WH-1000XM4 wireless noise-canceling headphones. They're great for music lovers. Only $299.99. Interested? Shoot me an email at musiclover@schnurrio.invalid!",
                Price = 299.99m,
                CreatedBy = "tony.strong@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = new File { Name = "sony_headphones.jpg", Path = "/images/sony_headphones.jpg" },
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 12, 20),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 16,
                Title = "Xbox Series X Gaming Console",
                Description = "Hey, I'm selling an Xbox Series X gaming console. It's great for gaming. Only $499.99. Interested? Drop me a message at gamer@schnurrio.invalid!",
                Price = 499.99m,
                CreatedBy = "aron.sheppert@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = new File { Name = "xbox_series_x.jpg", Path = "/images/xbox_series_x.jpg" },
                CreatedAt = new DateTime(2022, 12, 5),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 17,
                Title = "Canon EOS 90D DSLR Camera",
                Description = "Hey, I'm selling a Canon EOS 90D DSLR camera. It's great for photography and videography. Only $1199.99. Interested? Shoot me an email at photographer@schnurrio.invalid!",
                Price = 1199.99m,
                CreatedBy = "tony.strong@schnurrio.invalid",
                Condition = AdvertisementCondition.VeryGood,
                Image = new File { Name = "canon_eos_90d.jpg", Path = "/images/canon_eos_90d.jpg" },
                CreatedAt = new DateTime(2022, 11, 15),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 18,
                Title = "LG OLED 55-Inch 4K Smart TV",
                Description = "Hello, I'm selling an LG OLED 55-inch 4K Smart TV. It's great for watching movies and shows. Only $1299.99. Interested? Drop me a message at entertainmentguy@schnurrio.invalid!",
                Price = 1299.99m,
                CreatedBy = "natsumi.phot@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = new File { Name = "lg_oled_tv.jpg", Path = "/images/lg_oled_tv.jpg" },
                CreatedAt = new DateTime(2022, 10, 25),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 19,
                Title = "Fitbit Versa 4 Fitness Tracker",
                Description = "Hey, I'm selling a Fitbit Versa 4 fitness tracker. It's great for tracking your activity. Only $149.99. Interested? Shoot me an email at fitnessguy@schnurrio.invalid!",
                Price = 149.99m,
                CreatedBy = "cornelia.runna@schnurrio.invalid",
                Condition = AdvertisementCondition.VeryGood,
                Image = new File { Name = "fitbit_versa.jpg", Path = "/images/fitbit_versa.jpg" },
                CreatedAt = new DateTime(2022, 9, 10),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 20,
                Title = "KitchenAid Stand Mixer",
                Description = "Hey there, I'm selling a KitchenAid stand mixer. It's great for baking and cooking. Only $299.99. Interested? Drop me a message at chef@schnurrio.invalid!",
                Price = 299.99m,
                CreatedBy = "max.petersen@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = new File { Name = "kitchenaid_mixer.jpg", Path = "/images/kitchenaid_mixer.jpg" },
                CreatedAt = new DateTime(2022, 8, 20),
                DeletedAt = new DateTime(2023, 8, 20),
            },
            new Advertisement
            {
                Id = 21,
                Title = "Amazon Kindle Paperwhite E-Reader",
                Description = "Hi, I'm selling an Amazon Kindle Paperwhite E-Reader. It's perfect for reading. Only $129.99. Interested? Shoot me an email at bookworm@schnurrio.invalid!",
                Price = 129.99m,
                CreatedBy = "marianne.black@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = new File { Name = "kindle_paperwhite.jpg", Path = "/images/kindle_paperwhite.jpg" },
                CreatedAt = new DateTime(2022, 7, 5),
                DeletedAt = new DateTime(2022, 9, 17),
            },
            new Advertisement
            {
                Id = 22,
                Title = "Samsung 32-Inch Curved Gaming Monitor",
                Description = "Hey, I'm selling a Samsung 32-inch curved gaming monitor. It's great for gaming. Only $349.99. Interested? Drop me a message at gamer@schnurrio.invalid!",
                Price = 349.99m,
                CreatedBy = "john.ung@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = new File { Name = "samsung_monitor.jpg", Path = "/images/samsung_monitor.jpg" },
                CreatedAt = new DateTime(2022, 6, 15),
                DeletedAt = new DateTime(2023, 1, 1),
            },
            new Advertisement
            {
                Id = 23,
                Title = "Leather Office Chair",
                Description = "Hello, I'm selling a leather office chair. It's great for your workspace. Only $199.99. Interested? Shoot me an email at officeguy@schnurrio.invalid!",
                Price = 199.99m,
                CreatedBy = "kim.phut@schnurrio.invalid",
                Condition = AdvertisementCondition.Good,
                Image = new File { Name = "office_chair.jpg", Path = "/images/office_chair.jpg" },
                CreatedAt = new DateTime(2022, 5, 20),
                DeletedAt = new DateTime(2023, 4, 10),
            },
            new Advertisement
            {
                Id = 24,
                Title = "Nintendo Switch Gaming Console",
                Description = "Hey there, I'm selling a Nintendo Switch gaming console. It's great for gaming on the go. Only $299.99. Interested? Drop me a message at gaming@schnurrio.invalid!",
                Price = 299.99m,
                CreatedBy = "carla.carlson@schnurrio.invalid",
                Condition = AdvertisementCondition.VeryGood,
                Image = new File { Name = "nintendo_switch.jpg", Path = "/images/nintendo_switch.jpg" },
                CreatedAt = new DateTime(2022, 4, 10),
                DeletedAt = new DateTime(2022, 5, 11),
            },
            new Advertisement
            {
                Id = 25,
                Title = "Nespresso Vertuo Coffee Machine",
                Description = "Hi, I'm selling a Nespresso Vertuo coffee machine. It's perfect for coffee lovers. Only $149.99. Interested? Shoot me an email at coffeelover@schnurrio.invalid!",
                Price = 149.99m,
                CreatedBy = "john.doe@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = new File { Name = "nespresso_machine.jpg", Path = "/images/nespresso_machine.jpg" },
                CreatedAt = new DateTime(2022, 3, 5),
                DeletedAt = new DateTime(2022, 3, 20),
            }
        };

        return advertisements;
    }
}