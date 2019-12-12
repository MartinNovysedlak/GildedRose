using System.Collections.Generic;

namespace GildedRose
{
    class Inventory
    {
        private readonly IEnumerable<Item> items;

        public Inventory(IEnumerable<Item> items)
        {
            this.items = items;
        }

        /// <summary>
        /// Items:
        /// "+5 Dexterity Vest"
        /// "Aged Brie"
        /// "Elixir of the Mongoose"
        /// "Sulfuras, Hand of Ragnaros"
        /// "Backstage passes to a TAFKAL80ETC concert"
        /// "Conjured Mana Cake"
        /// </summary>
        public void UpdateQuality()
        {
            foreach(var item in items)
            {
                if (item.Name == "Sulfuras")
                {
                    continue;
                }
                    item.SellIn--;
                if(item.Name == "Aged Brie")
                {
                    item.Quality++;
                    if(item.SellIn <= 0)
                    {
                        item.Quality++;
                    }
                }

                if(item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    item.Quality++;
                    if(item.SellIn <= 0)
                    {
                        item.Quality = 0;
                    }
                    if (item.SellIn <= 5)
                    {
                        item.Quality += 2;
                    }
                    if (item.SellIn <= 10)
                    {
                        item.Quality += 3;
                    }
                }
                if (item.Name == "Conjured Mana Cake")
                {
                   
                    if(item.SellIn <= -1)
                    {
                        item.Quality -= 4;
                    }
                    else
                    {
                        item.Quality -= 2;
                    }
                }

                if (item.Quality <= 0) item.Quality = 0;
                if (item.Quality >= 50) item.Quality = 50;
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    item.Quality = 80;
                    item.SellIn = 0;
                }

            }
        }
    }
}
