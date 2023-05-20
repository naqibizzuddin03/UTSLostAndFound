using System.Collections.ObjectModel;

namespace UTSLostAndFound.Model
{
    public static class ItemData
    {
        public static ObservableCollection<ProductListModel> LostItemDataList { get; } = new ObservableCollection<ProductListModel>()
        {
            new ProductListModel() { Name = "Speekah", LastSeen = "Last seen:", Date = "02/03/2023", Image = "Image/image1", Details = "a big speaker, i left it at the LTC and now it's gone! please help me find it. Thank you", ContactNumber = "0136827277" },
            new ProductListModel() { Name = "Leather Wristwatch", LastSeen = "Last seen:", Date = "26/04/2023", Image = "Image/image2", Details = "A simple wristwatch for a simple man, please do contact me if you found it.", ContactNumber = "0135431290" },
            new ProductListModel() { Name = "ASMR device", LastSeen = "Last seen:", Date = "18/04/2023", Image = "Image/image3", Details = "An ASMR device, even better sound and quality than any other speaker. please contact me if you manage to find it", ContactNumber = "013773156" },
            new ProductListModel() { Name = "Overpriced earbuds", LastSeen = "Last seen:", Date = "04/05/2023", Image = "Image/image4", Details = "An earbud i just buyed, when i was running late to class i accidentally dropped it soemwhere along the way. PLEASEEE CONTACT ME IF YOU FOUND ITT.", ContactNumber = "013778880" }
        };

        public static ObservableCollection<ProductListModel> FoundItemDataList { get; } = new ObservableCollection<ProductListModel>()
        {
            new ProductListModel() { Name = "Ipong Promax", LastSeen = "Last seen:", Date = "01/03/2023", Image = "Image/image6", Details = "Its a phone, and its colored gold!, i don't know if someone would return such thing but it was me who found it... lucky you", ContactNumber = "013220149" },
            new ProductListModel() { Name = "Rollex Wristwatch", LastSeen = "Last seen:", Date = "26/04/2023", Image = "Image/image7", Details = "An expensive wristwatch for a rish man, please do contact me if you lost it.", ContactNumber = "0137884070" },
            new ProductListModel() { Name = "RazorSharp Laptop", LastSeen = "Last seen:", Date = "18/04/2023", Image = "Image/image8", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. But seriously i'm out of idea for this one...", ContactNumber = "0137317250" },
            new ProductListModel() { Name = "Produa Mercedes", LastSeen = "Last seen:", Date = "04/05/2023", Image = "Image/image9", Details = "It's a bird, no it's a plane, NO... it's the one and only key car for Produa Mercedes. Please do contact me if youre the person who lost the key.", ContactNumber = "013763390" }
        };
    }
}
