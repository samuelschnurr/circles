using Io.Schnurr.Circles.Shared.Enums;
using Io.Schnurr.Circles.Shared.Models;

namespace Io.Schnurr.Circles.Api.TestData;

internal static class TestAdvertisements
{
    private const string FolderPath = "./TestData/Images/";
    private const string MimeType = "image/jpeg;";

    internal static readonly List<Advertisement> advertisements = new()
        {
            new Advertisement
            {
                Id = 1,
                Title = "Wooden Jewelry Box",
                Description = "I'm selling this exquisite wooden jewelry box because it has been a cherished part of my life, and now I'd like someone else to enjoy its timeless beauty. It's in excellent condition, meticulously cared for. Inside, you'll find a well-organized haven for your precious jewelry. Trust me; this jewelry box is not just functional; it's a work of art that adds sophistication to any room.\nCrafted from rich mahogany wood, this jewelry box exudes warmth and character. The intricate woodwork and attention to detail make it a piece that will catch your eye every time you enter the room. The felt-lined compartments inside are designed to cradle your jewelry, keeping them safe from scratches and tangles.\nWhether you're a collector of fine jewelry or simply want an elegant storage solution, this wooden jewelry box fits the bill. Its classic design ensures it complements any decor style, from vintage to modern. Imagine opening this box each day to choose the perfect accessory for your outfit, knowing that it has a history of being treasured.\nDon't miss the opportunity to own this beautiful piece of craftsmanship. It's not just a jewelry box; it's a conversation starter, a piece of art, and a functional storage solution. Display your jewelry collection with pride in this exquisite wooden jewelry box.",
                Price = 49.99m,
                CreatedBy = "jane.doe@schnurrio.invalid",
                Condition = AdvertisementCondition.VeryGood,
                Image = GetImageAsBrowserFile("jewelrybox.jpg"),
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 7, 15),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 2,
                Title = "Custom Hand-Painted Portrait",
                Description = "I've always had a passion for art, which is why I'm thrilled to offer custom hand-painted portraits. Each artwork is a labor of love, capturing the essence of your favorite photos in a unique and beautiful way. I take great pride in my work, ensuring that every brushstroke is infused with passion and creativity. Elevate your decor with a personalized hand-painted portrait that tells your unique story.",
                Price = 199.99m,
                CreatedBy = "max.due@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = GetImageAsBrowserFile("portrait.jpg"),
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 6, 20),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 3,
                Title = "Pure Organic Honey",
                Description = "Pure, organic honey has been a staple in my life, and I'm excited to share it with you. It's the result of nature's sweetest gift, with no additives or processing. My honey is a golden elixir of natural goodness, bursting with flavor and health benefits. Whether drizzled over your morning toast or stirred into a soothing cup of tea, my organic honey adds a touch of pure sweetness to your day. Experience the authentic taste of nature with our organic honey.",
                Price = 14.99m,
                CreatedBy = "peter.corla@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = GetImageAsBrowserFile("honey.jpg"),
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 6, 10),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 4,
                Title = "Greeting Cards",
                Description = "Crafting personalized greeting cards has been a labor of love for me. Each card carries a heartfelt message because I believe that special moments deserve personalized sentiments. My collection features a range of designs, from whimsical to elegant, ensuring there's a card for every occasion. Whether you're sending birthday wishes, expressing sympathy, or saying thank you, my greeting cards make your sentiments truly special. Share your emotions with a personalized greeting card that speaks volumes.",
                Price = 4.99m,
                CreatedBy = "tanja.maker@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = GetImageAsBrowserFile("greetingcards.jpg"),
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 5, 30),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 5,
                Title = "Organic Garden Vegetables",
                Description = "I've always been passionate about organic gardening, and now I'm delighted to offer you fresh, homegrown vegetables straight from my garden. It's a commitment to sustainable farming practices and a love for all things green. My organic vegetables are free from chemicals and pesticides. From crisp lettuce to juicy tomatoes, they are bursting with flavor and nutrition. Elevate your meals with the goodness of my organic garden vegetables.",
                Price = 2.99m,
                CreatedBy = "franz.lustig@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = GetImageAsBrowserFile("vegetables.jpg"),
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 5, 15),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 6,
                Title = "Stainless Steel Water Bottle",
                Description = "Stay hydrated in style and make a positive impact on the environment with our Stainless Steel Water Bottle. This versatile and eco-conscious water bottle is designed to elevate your hydration routine while reducing single-use plastic waste. With a sleek and durable stainless steel construction, it's the perfect choice for eco-warriors, fitness enthusiasts, and anyone looking to make a sustainable change in their daily lives.\nDesign and Durability\nCrafted from high-quality stainless steel, this water bottle is built to withstand the rigors of everyday life. Its robust design ensures it can handle your active lifestyle, from hikes in the wilderness to yoga sessions at the gym. The stainless steel material is not only incredibly durable but also resistant to rust and corrosion, guaranteeing long-lasting performance.\nEco-Friendly Choice\nBy choosing our Stainless Steel Water Bottle, you're taking a significant step towards reducing plastic pollution. Every time you fill up your reusable bottle instead of buying a disposable one, you're helping to reduce the millions of plastic bottles that end up in landfills and oceans. It's a small change that makes a big difference.\nHydration on the Go\nStay refreshed and hydrated wherever life takes you. This water bottle is designed for convenience with a leak-proof lid that prevents spills and a wide-mouth opening for easy filling and cleaning. Its sleek and slim design fits perfectly in most cup holders, backpack pockets, or gym bags, making it your ideal travel companion.\nKeep Your Drinks at the Perfect Temperature\nWhether you prefer ice-cold water on a scorching summer day or a piping hot beverage during the winter months, our Stainless Steel Water Bottle has you covered. The double-wall insulation keeps your drinks at the desired temperature for hours. Say goodbye to lukewarm sips and hello to refreshingly cold or delightfully hot drinks whenever you please.\nHealth and Safety First\nWe understand that your health is a top priority. That's why our water bottle is made from BPA-free and toxin-free stainless steel. You can enjoy your drinks with confidence, knowing that your water bottle won't leach harmful chemicals into your beverages. It's the safe and responsible choice for you and the planet.\nExpress Your Style\nAvailable in a range of colors and finishes, our Stainless Steel Water Bottle allows you to express your personal style. Whether you prefer a classic brushed steel look or a vibrant, eye-catching color, there's a bottle to match your taste. Make a statement while staying hydrated.\nA Greener Future Starts Today\nJoin the movement towards a greener and more sustainable future with the Stainless Steel Water Bottle. By making the switch to reusable bottles, you're not only reducing waste but also conserving resources and minimizing your carbon footprint. It's a simple yet powerful way to contribute to a healthier planet for future generations.\nIn conclusion, the Stainless Steel Water Bottle is more than just a hydration vessel; it's a statement of your commitment to a sustainable lifestyle. Make the eco-friendly choice today and enjoy the benefits of a durable, stylish, and planet-friendly water bottle. Stay hydrated, stay responsible, and make a positive impact with every sip. Choose our Stainless Steel Water Bottle and be part of the solution to a plastic-free world.",
                Price = 19.99m,
                CreatedBy = "matthias.dorp@schnurrio.invalid",
                Condition = AdvertisementCondition.Good,
                Image = GetImageAsBrowserFile("waterbottle.jpg"),
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 7, 5),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 7,
                Title = "Wireless Bluetooth Earbuds",
                Description = "Upgrade your audio experience with our Wireless Bluetooth Earbuds. Whether you're a music enthusiast, podcast lover, or someone who values clear calls on the go, these earbuds have you covered. With their advanced features, comfortable fit, and sleek design, they're the perfect choice for those who demand the best in wireless audio technology.\nIn conclusion, our Wireless Bluetooth Earbuds offer a world of convenience and high-quality audio at your fingertips. Say goodbye to the limitations of wired headphones and embrace the freedom of wireless audio. Elevate your listening experience, stay connected, and enjoy music the way it's meant to be heard with our Wireless Bluetooth Earbuds. Upgrade your audio game today.",
                Price = 39.99m,
                CreatedBy = "jane.doe@schnurrio.invalid",
                Condition = AdvertisementCondition.VeryGood,
                Image = GetImageAsBrowserFile("earbuds.jpg"),
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 9, 25),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 8,
                Title = "Classic leather wallet",
                Description = "I've decided to part with my classic leather wallet. It has served me faithfully and deserves to find a new home. Crafted from genuine leather, it exudes timeless elegance and character. Despite showing some signs of wear, it still holds up well and can be a great accessory for someone with a penchant for the classics. Embrace the charm of a well-loved leather wallet.",
                Price = 29.99m,
                CreatedBy = "karl.tenter@schnurrio.invalid",
                Condition = AdvertisementCondition.Acceptable,
                Image = GetImageAsBrowserFile("wallet.jpg"),
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 1, 15),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 9,
                Title = "Ceramic Coffee Mug Set",
                Description = "Hosting friends or family? This ceramic coffee mug set is perfect for those cozy gatherings. I've enjoyed many conversations over these mugs, and they've held up wonderfully. Each mug comes in a different vibrant color, adding a touch of cheer to your coffee sessions. They're not just mugs; they're storytellers of cherished moments. Make every sip special with this ceramic coffee mug set.",
                Price = 24.99m,
                CreatedBy = "nico.baristata@schnurrio.invalid",
                Condition = AdvertisementCondition.Acceptable,
                Image = GetImageAsBrowserFile("mugs.jpg"),
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 12, 5),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 10,
                Title = "Camping Tent for Two",
                Description = "If you're an outdoor enthusiast like me, you'll appreciate this camping tent for two. It has been my reliable shelter in various weather conditions, and it's time for it to accompany someone else on their adventures.\nSetting it up is a breeze, thanks to its intuitive design and color-coded poles. Even if you're new to camping, you'll have this tent ready in minutes, allowing you to focus on the beauty of the great outdoors.\nThe durable materials and waterproof rainfly ensure that you stay dry and comfortable, no matter the weather. Whether you're camping in the wilderness, by a serene lakeside, or under the starry night sky, this tent provides the perfect sanctuary.\nInside, you'll find ample space for two with storage pockets to keep your gear organized. The mesh windows offer ventilation, and the sturdy zippers ensure easy access. It's your home away from home, designed for adventurers who appreciate both comfort and simplicity.\nEmbark on your next camping trip with confidence, knowing you have a trustworthy companion in this tent. Create lasting memories in the great outdoors and let this tent be your reliable shelter on your next adventure.",
                Price = 79.99m,
                CreatedBy = "vald.korsko@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = GetImageAsBrowserFile("campingtent.jpg"),
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 5, 20),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 11,
                Title = "Sony 65-Inch 4K Ultra HD Smart LED TV",
                Description = "Movie nights will never be the same with this Sony 65-inch 4K Ultra HD Smart LED TV. I've enjoyed countless cinematic experiences on this screen, and it delivers stunning visuals and immersive sound.\nThe 4K Ultra HD resolution means you'll see every detail with crystal clarity, from the subtlest expressions on actors' faces to the breathtaking landscapes of your favorite films. This TV's Triluminos display technology enhances color accuracy, ensuring vibrant and lifelike images.\nBut it's not just about visuals; the Dolby Atmos audio technology transports you into the heart of the action. Feel the rumble of a movie's soundtrack, the whispers of dialogue, and the roar of explosions, all with precision and depth.\nWith smart functionality, this TV connects seamlessly to streaming platforms, giving you access to a vast library of content. You can binge-watch your favorite series, catch up on the latest documentaries, or enjoy family movie nights with ease.\nMultiple HDMI and USB ports make connecting your devices a breeze. Whether you're a gaming enthusiast or want to showcase your latest vacation photos, this TV accommodates all your entertainment needs.\nGet ready to be captivated by the world of 4K. This Sony TV is more than just a screen; it's a gateway to a world of visual and auditory wonders. Transform your living room into a private cinema and immerse yourself in the magic of high-definition entertainment.\nThese extended descriptions provide a deeper understanding of the products, emphasizing their unique features and benefits.",
                Price = 899.99m,
                CreatedBy = "jane.doe@schnurrio.invalid",
                Condition = AdvertisementCondition.VeryGood,
                Image = GetImageAsBrowserFile("sony_tv.jpg"),
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 4, 10),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 12,
                Title = "Apple MacBook Pro 15-Inch Laptop",
                Description = "As a tech enthusiast, I've cherished my Apple MacBook Pro 15-inch laptop. It's been my reliable companion for work and play. With a powerful processor and a brilliant display, it's a powerhouse for productivity and creativity. It's in excellent condition and ready to enhance your digital experiences. Make this MacBook Pro your new creative canvas.",
                Price = 1899.99m,
                CreatedBy = "steve.works@schnurrio.invalid",
                Condition = AdvertisementCondition.VeryGood,
                Image = GetImageAsBrowserFile("macbook_pro.jpg"),
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 1, 15),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 13,
                Title = "DJI Mavic Air 2 Drone",
                Description = "Take your photography and videography to new heights with the DJI Mavic Air 2 drone. I've explored breathtaking landscapes and captured stunning footage with this drone. It's a marvel of technology, offering exceptional stability and image quality. Whether you're a seasoned drone pilot or a beginner, this DJI Mavic Air 2 takes your aerial photography to the next level. Discover the world from a new perspective.",
                Price = 799.99m,
                CreatedBy = "sam.strick@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = GetImageAsBrowserFile("mavic_air_2.jpg"),
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 11, 25),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 14,
                Title = "Samsung Galaxy S22 Ultra Smartphone",
                Description = "Are you looking for a smartphone that combines style and functionality? The Samsung Galaxy S22 Ultra is a fantastic choice. I've been impressed by its camera capabilities and its stunning display. It's a versatile device that can handle your daily tasks with ease. Experience the best of Samsung's innovation in the palm of your hand. Elevate your smartphone game with the Galaxy S22 Ultra.",
                Price = 1099.99m,
                CreatedBy = "cordula.blue@schnurrio.invalid",
                Condition = AdvertisementCondition.Good,
                Image = GetImageAsBrowserFile("samsung_s22.jpg"),
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 2, 10),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 15,
                Title = "Sony WH-1000XM4 Wireless Noise-Canceling Headphones",
                Description = "Immerse yourself in the world of music with these Sony WH-1000XM4 wireless noise-canceling headphones. I've enjoyed countless hours of uninterrupted music with these headphones. They deliver exceptional sound quality, making every note come alive. The noise-canceling technology ensures that you can savor your music in peace, no matter where you are. Elevate your auditory experience with Sony.",
                Price = 299.99m,
                CreatedBy = "tony.strong@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = GetImageAsBrowserFile("sony_headphones.jpg"),
                CreatedAt = new DateTime(DateTime.Now.Year - 1, 12, 20),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 16,
                Title = "Xbox Series X Gaming Console",
                Description = "Calling all gamers! The Xbox Series X gaming console is your ticket to gaming nirvana. I've embarked on epic gaming journeys with this console, and it has never disappointed. With top-notch graphics and processing power, it's a gamer's dream come true. Whether you're into action, adventure, or sports, this console delivers an immersive experience. Level up your gaming setup with the Xbox Series X.",
                Price = 499.99m,
                CreatedBy = "aron.sheppert@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = GetImageAsBrowserFile("xbox_series_x.jpg"),
                CreatedAt = new DateTime(2022, 12, 5),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 17,
                Title = "Canon EOS 90D DSLR Camera",
                Description = "Unleash your creativity with the Canon EOS 90D DSLR camera. I've captured stunning moments and created lasting memories with this camera. It's a versatile tool for both photography and videography, offering impressive performance and image quality. Whether you're a budding photographer or a seasoned pro, the Canon EOS 90D empowers you to unleash your artistic vision. Capture the world in exquisite detail.",
                Price = 1199.99m,
                CreatedBy = "tony.strong@schnurrio.invalid",
                Condition = AdvertisementCondition.VeryGood,
                Image = GetImageAsBrowserFile("canon_eos_90d.jpg"),
                CreatedAt = new DateTime(2022, 11, 15),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 18,
                Title = "LG OLED 55-Inch 4K Smart TV",
                Description = "Elevate your home entertainment with the LG OLED 55-inch 4K Smart TV. I've enjoyed countless movie nights and gaming sessions on this TV. Its OLED technology delivers stunning visuals with deep blacks and vibrant colors. Whether you're a cinephile or a gamer, this TV brings your favorite content to life like never before. Transform your living room into a cinematic paradise with LG.",
                Price = 1299.99m,
                CreatedBy = "natsumi.phot@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = GetImageAsBrowserFile("lg_oled_tv.jpg"),
                CreatedAt = new DateTime(2022, 10, 25),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 19,
                Title = "Fitbit Versa 4 Fitness Tracker",
                Description = "Keep track of your fitness goals with the Fitbit Versa 4 fitness tracker. I've relied on it to monitor my activity and stay motivated. It's a sleek and intuitive device that helps you achieve a healthier lifestyle. With its range of features, including heart rate monitoring and sleep tracking, it's a valuable companion on your fitness journey. Take control of your health and wellness with Fitbit Versa 4.",
                Price = 149.99m,
                CreatedBy = "cornelia.runna@schnurrio.invalid",
                Condition = AdvertisementCondition.VeryGood,
                Image = GetImageAsBrowserFile("fitbit_versa.jpg"),
                CreatedAt = new DateTime(2022, 9, 10),
                DeletedAt = null
            },
            new Advertisement
            {
                Id = 20,
                Title = "Leather Office Chair",
                Description = "Upgrade your workspace with this leather office chair. It has been my trusted companion for long hours of work, providing comfort and support. The genuine leather upholstery adds a touch of sophistication to any office setting. Whether you're working from home or in a professional environment, this chair offers both style and functionality. Elevate your workspace with the leather office chair.",
                Price = 199.99m,
                CreatedBy = "test.user@schnurrio.invalid",
                Condition = AdvertisementCondition.Good,
                Image = GetImageAsBrowserFile("office_chair.jpg"),
                CreatedAt = new DateTime(2022, 5, 20),
                DeletedAt = null,
            },
            new Advertisement
            {
                Id = 21,
                Title = "KitchenAid Stand Mixer",
                Description = "If you're a culinary enthusiast, you'll appreciate the KitchenAid Stand Mixer. I've used it to whip up countless delicious recipes, and it has never let me down. With its powerful performance and versatile attachments, it's a must-have for any home chef. Elevate your baking and cooking endeavors with the KitchenAid Stand Mixer.",
                Price = 299.99m,
                CreatedBy = "max.petersen@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = GetImageAsBrowserFile("kitchenaid_mixer.jpg"),
                CreatedAt = new DateTime(2022, 8, 20),
                DeletedAt = new DateTime(2023, 8, 20),
            },
            new Advertisement
            {
                Id = 22,
                Title = "Amazon Kindle Paperwhite E-Reader",
                Description = "Dive into the world of literature with the Amazon Kindle Paperwhite E-Reader. I've immersed myself in countless books with this device, and it has been a loyal companion. With its glare-free display and weeks-long battery life, it's the perfect device for bookworms. Embark on literary adventures and discover new worlds with the Kindle Paperwhite.",
                Price = 129.99m,
                CreatedBy = "marianne.black@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = GetImageAsBrowserFile("kindle_paperwhite.jpg"),
                CreatedAt = new DateTime(2022, 7, 5),
                DeletedAt = new DateTime(2022, 9, 17),
            },
            new Advertisement
            {
                Id = 23,
                Title = "Samsung 32-Inch Curved Gaming Monitor",
                Description = "Experience gaming like never before with the Samsung 32-inch curved gaming monitor. I've had epic gaming sessions on this monitor, and its curved design adds a level of immersion that's hard to beat. With fast refresh rates and vibrant visuals, it's a game-changer for gamers. Dive into your favorite titles with the Samsung curved gaming monitor.",
                Price = 349.99m,
                CreatedBy = "john.ung@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = GetImageAsBrowserFile("samsung_monitor.jpg"),
                CreatedAt = new DateTime(2022, 6, 15),
                DeletedAt = new DateTime(2023, 1, 1),
            },

            new Advertisement
            {
                Id = 24,
                Title = "Nintendo Switch Gaming Console",
                Description = "Gaming on the go has never been easier with the Nintendo Switch gaming console. I've embarked on countless adventures with this console, and it's been a source of endless entertainment. With its versatile design, you can enjoy gaming anytime, anywhere. Whether you're a solo gamer or love multiplayer action, the Nintendo Switch delivers fun for all ages. Take the thrill of gaming with you wherever you roam.",
                Price = 299.99m,
                CreatedBy = "carla.carlson@schnurrio.invalid",
                Condition = AdvertisementCondition.VeryGood,
                Image = GetImageAsBrowserFile("nintendo_switch.jpg"),
                CreatedAt = new DateTime(2022, 4, 10),
                DeletedAt = new DateTime(2022, 5, 11),
            },
            new Advertisement
            {
                Id = 25,
                Title = "Nespresso Vertuo Coffee Machine",
                Description = "Calling all coffee lovers! The Nespresso Vertuo Coffee Machine is a game-changer in your morning routine. I've savored countless cups of rich, aromatic coffee with this machine. It's designed for convenience and quality, delivering barista-worthy brews with the touch of a button. Say goodbye to the hassle of traditional coffee-making and savor the perfect cup every time. Transform your mornings with the Nespresso Vertuo Coffee Machine.",
                Price = 149.99m,
                CreatedBy = "john.doe@schnurrio.invalid",
                Condition = AdvertisementCondition.New,
                Image = GetImageAsBrowserFile("nespresso_machine.jpg"),
                CreatedAt = new DateTime(2022, 3, 5),
                DeletedAt = new DateTime(2022, 3, 20),
            }
        };

    private static BrowserFile GetImageAsBrowserFile(string fileName)
    {
        var bytes = File.ReadAllBytes(FolderPath + fileName);
        var base64Bytes = Convert.ToBase64String(bytes);
        var base64String = string.Format("data:{0}base64,{1}", MimeType, base64Bytes);

        return new BrowserFile() { Base64File = base64String, Name = fileName, Size = bytes.LongLength, ContentType = MimeType };

    }
}