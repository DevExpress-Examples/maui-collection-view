using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewLongTapExamp {
    public static class DataGenerator {
        public static ObservableCollection<EmailMessage> CreateEmailMessages() {
            return new ObservableCollection<EmailMessage>() {
                new EmailMessage(){ Title = "Your Favorite Shakespeare Play", SenderAvatarPath = "albertmenendez", Sender="Albert Menendez", Date=DateTime.Now, Body="Hello. We’ve got an open poll and you are the only two who have yet to respond. Which is your favorite Shakespeare play?" },
                new EmailMessage(){ Title = "Wikipedia Says I'm Right", SenderAvatarPath = "karenholmes", Sender="Karen Holmes", Date=DateTime.Now.AddDays(-1), Body="HI Guys. I told you I was right…The longest river in the world is the Nile." },
                new EmailMessage(){ Title = "My Favorite Resort in Las Vegas", SenderAvatarPath = "samhill", Sender="Sam Hill", Date=DateTime.Now.AddDays(-3), Body="Hello Robin. Here is a photo of my favorite resort in Las Vegas." },
                new EmailMessage(){ Title = "Circuit Town Orders", SenderAvatarPath = "benjaminjohonson", Sender="Benjamin Johonson", Date=DateTime.Now.AddDays(-3), Body="Circuit Town has been ordering a lot of products recently. Did you thank them already or did you want me to reach out? Please advise." },
                new EmailMessage(){ Title = "Cabling and Termination", SenderAvatarPath = "alexjames", Sender="Alex James", Date=DateTime.Now.AddDays(-4), Body="Taylor, you need to learn how to terminate twisted-pair cables. I neither have the time nor the patience to teach you. Search the web and you’ll come across countless tutorials." },
                new EmailMessage(){ Title = "Icons, Icons and More Icons", SenderAvatarPath = "alfrednewman", Sender="Alfred Newman", Date=DateTime.Now.AddDays(-10), Body="Just a quick heads-up…DevExpress has released a large icon library which we can use to improve the appearance of the Ribbon control within our app. The icons we’ve been using are old and dated…" },
                new EmailMessage(){ Title = "Your Hard Work is Appreciated", SenderAvatarPath = "bobbievalentine", Sender="Bobbie Valentine", Date=DateTime.Now.AddDays(-26), Body="I heard you’ve been dealing with some personal issues and I wanted to let you know that I’m here to help you in any way I can." },
                new EmailMessage(){ Title = "Online Sales and Growing", SenderAvatarPath = "frankfrankson", Sender="Frank Frankson", Date=DateTime.Now.AddDays(-27), Body="Looks like online sales continue to outpace expectations. What accounts for the increase? Do you see anything that might disrupt growth in the coming year?\r\n" },
                new EmailMessage(){ Title = "Your Favorite Font", SenderAvatarPath = "jennievalintine", Sender="Jennie Valintine", Date=DateTime.Now.AddDays(-29), Body="HI Ya Morgan. Which of these is your favorite font?" },
                new EmailMessage(){ Title = "Join Us for Lunch?", SenderAvatarPath = "jimmiejones", Sender="Jimmie Jones", Date=DateTime.Now.AddDays(-35), Body="Samantha and I are going to lunch at the new restaurant down the street. Apparently the make amazing deep-dish pizza. Would you like to join us?" }
            };
        }
    }
}
