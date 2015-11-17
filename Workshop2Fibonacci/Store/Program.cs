namespace Store
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Product
    {
        public Product(string name, decimal price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Producer { get; set; }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer, this.Price);
        }
    }

    class OnlineStore
    {
        private readonly Dictionary<string, List<Product>> productsByName;
        private readonly Dictionary<string, List<Product>> productsProducere;
        private readonly Dictionary<string, List<Product>> productsByNameNadProducer;
        private readonly Dictionary<decimal, List<Product>> productsByPrice;

        public OnlineStore()
        {
            this.productsByName = new Dictionary<string, List<Product>>();
            this.productsProducere = new Dictionary<string, List<Product>>();
            this.productsByNameNadProducer = new Dictionary<string, List<Product>>();
            this.productsByPrice = new Dictionary<decimal, List<Product>>();
        }

        public string AddProduct(string productName, decimal price, string producer)
        {
            var newProduct = new Product(productName, price, producer);

            if (!this.productsByName.ContainsKey(productName))
            {
                this.productsByName.Add(productName, new List<Product>());
            }

            if (!this.productsProducere.ContainsKey(producer))
            {
                this.productsProducere.Add(producer, new List<Product>());
            }

            if (!this.productsByNameNadProducer.ContainsKey(productName + producer))
            {
                this.productsByNameNadProducer.Add(productName + producer, new List<Product>());
            }

            if (!this.productsByPrice.ContainsKey(price))
            {
                this.productsByPrice.Add(price, new List<Product>());
            }

            this.productsByName[productName].Add(newProduct);
            this.productsProducere[producer].Add(newProduct);
            this.productsByNameNadProducer[productName + producer].Add(newProduct);
            this.productsByPrice[price].Add(newProduct);

            return "Product added";
        }

        public string DeleteProducts(string productName, string producer)
        {
            var index = productName + producer;

            if (!this.productsByNameNadProducer.ContainsKey(index))
            {
                return "No products found";
            }

            var productsToDelete = this.productsByNameNadProducer[index];
            var deletedCOunt = productsToDelete.Count();

            if (deletedCOunt == 0)
            {
                return "No products found";
            }

            foreach (var pr in productsToDelete)
            {
                this.productsByName[pr.Name].Remove(pr);
                this.productsProducere[pr.Producer].Remove(pr);
                this.productsByPrice[pr.Price].Remove(pr);
            }

            this.productsByNameNadProducer.Remove(index);

            return string.Format("{0} products deleted", deletedCOunt);
        }

        public string DeleteProducts(string producer)
        {
            if (!this.productsProducere.ContainsKey(producer))
            {
                return "No products found";
            }

            var productsToDelete = this.productsProducere[producer];
            var deletedCOunt = productsToDelete.Count();

            if (deletedCOunt == 0)
            {
                return "No products found";
            }

            foreach (var pr in productsToDelete)
            {
                this.productsByName[pr.Name].Remove(pr);
                this.productsByNameNadProducer[pr.Name + pr.Producer].Remove(pr);
                this.productsByPrice[pr.Price].Remove(pr);
            }

            this.productsProducere.Remove(producer);

            return string.Format("{0} products deleted", deletedCOunt);
        }

        public string FindProductsByName(string productName)
        {
            if (!this.productsByName.ContainsKey(productName))
            {
                return "No products found";
            }

            var foundProducts = this.productsByName[productName];

            if (foundProducts.Count == 0)
            {
                return "No products found";
            }

            return this.GetProductsSetToString(foundProducts);
        }

        public string FindProductsByPriceRange(decimal from, decimal to)
        {
            var foundProducts = this.productsByPrice.Where(i => i.Key >= from && i.Key <= to).SelectMany(x => x.Value).ToList();

            if (foundProducts.Count() == 0)
            {
                return "No products found";
            }

            return this.GetProductsSetToString(foundProducts);
        }

        public string FindProductsByProducer(string producer)
        {
            if (!this.productsProducere.ContainsKey(producer))
            {
                return "No products found";
            }

            var foundProducts = this.productsProducere[producer];

            if (foundProducts.Count == 0)
            {
                return "No products found";
            }

            return this.GetProductsSetToString(foundProducts);
        }

        private string GetProductsSetToString(List<Product> products)
        {
            if (products == null)
            {
                return null;
            }

            var sb = new StringBuilder();
            var sortedProducts = products.OrderBy(p => p.ToString());

            foreach (var pr in sortedProducts)
            {
                sb.AppendLine(pr.ToString());
            }

            return sb.ToString().Trim();
        }
    }

    class Program
    {
        static void Main()
        {
            //Console.SetIn(File.OpenText("../../input.txt"));
            int commandsCOunt = int.Parse(Console.ReadLine());

            var output = new StringBuilder();
            var store = new OnlineStore();

            for (int i = 0; i < commandsCOunt; i++)
            {
                string command = Console.ReadLine();
                int indexfWhiteSpace = command.IndexOf(" ");
                string commandName = command.Substring(0, indexfWhiteSpace);
                var commanParameters = command.Substring(indexfWhiteSpace + 1).Split(';');

                if (commandName == "AddProduct")
                {
                    output.AppendLine(store.AddProduct(commanParameters[0], decimal.Parse(commanParameters[1]), commanParameters[2]));
                }
                else if (commandName == "DeleteProducts")
                {
                    if (commanParameters.Length == 2)
                    {
                        output.AppendLine(store.DeleteProducts(commanParameters[0], commanParameters[1]));
                    }
                    else if (commanParameters.Length == 1)
                    {
                        output.AppendLine(store.DeleteProducts(commanParameters[0]));
                    }
                }
                else if (commandName == "FindProductsByName")
                {
                    output.AppendLine(store.FindProductsByName(commanParameters[0]));
                }
                else if (commandName == "FindProductsByPriceRange")
                {
                    output.AppendLine(store.FindProductsByPriceRange(decimal.Parse(commanParameters[0]), decimal.Parse(commanParameters[1])));
                }
                else if (commandName == "FindProductsByProducer")
                {
                    output.AppendLine(store.FindProductsByProducer(commanParameters[0]));
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}