namespace UTSLostAndFound.Model
{
    public class ProductDetail
    {
        private string image;

        public string Image
        {
            get { return image ?? "placeholder_image.png"; }
            set { image = value; }
        }

        public string Name { get; set; }
        public List<string> Sizes { get; set; }
        public List<ContactModel> Contact { get; set; }
        public Color Colors { get; set; }
        public string Details { get; set; }
        public string Date { get; set; }
        public string ContactNow { get; set; }
    }

    public class ContactModel
    {
        public string Image { get; set; }
        public string ContactNumber { get; set; }
        public string Number { get; set; }
    }
}
