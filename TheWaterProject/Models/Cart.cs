namespace TheWaterProject.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddItem(Project proj, int quantity)
        {
            CartLine? line = Lines
                .Where(x => x.Project.ProjectId == proj.ProjectId)
                .FirstOrDefault();

            //has it already been added to the cart
            if (line == null)
            {
                Lines.Add(new CartLine()
                {
                    Project = proj,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Project proj) => Lines.RemoveAll(x =>  x.Project.ProjectId == proj.ProjectId);

        public void Clear() => Lines.Clear();

        public decimal CalculateTotal() => Lines.Sum(x => 25 * x.Quantity);

            
        

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Project Project { get; set; }
            public int Quantity { get; set; }

        }
    }
}
