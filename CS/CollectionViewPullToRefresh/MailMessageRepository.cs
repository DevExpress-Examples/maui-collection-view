using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewPullToRefresh {
    public class MailData {
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime MailTime { get; set; }
    }
    public class MailMessageRepository {
        public List<MailData> MailMessages { get; private set; }
        readonly Random random;

        public MailMessageRepository() {
            this.random = new Random((int)DateTime.Now.Ticks);
            GenerateMessages();
        }

        public void GenerateMessages() {
            MailMessages = new List<MailData>();
            MailMessages.Add(
                new MailData() {
                    SenderName = "Nancy Davolio",
                    SenderEmail = "NancyDavolio@devexpress.com",
                    Subject = "Choose between PPO and HMO Health Plan",
                    Body = "We need a final decision on whether we are planning " +
                    "on staying with a PPO Health Plan or we plan on switching to an HMO. " +
                    "We cannot proceed with compliance with the Affordable Health Act " +
                    "until we make this decision. " +
                    "John Heart: Samantha, I'm still reviewing costs. " +
                    "I am not in a position to make a final decision at this point.",
                }
            );
            MailMessages.Add(
                new MailData() {
                    SenderName = "Andrew Fuller",
                    SenderEmail = "AndrewFuller@devexpress.com",
                    Subject = "Google AdWords Strategy",
                    Body = "Make final decision on whether we are going " +
                    "to increase our Google AdWord spend " +
                    "based on our 2013 marketing plan."
                }
            );
            MailMessages.Add(
                new MailData() {
                    SenderName = "Janet Leverling",
                    SenderEmail = "JanetLeverling@devexpress.com",
                    Subject = "New Brochures",
                    Body = "Review and the new brochure designs and give final approval. " +
                    "John Heart: we reviewed them all and forwarded an email with all changes we need " +
                    "to make to the brochures to comply with local regulations."
                }
            );
            MailMessages.Add(
                new MailData() {
                    SenderName = "Margaret Peacock",
                    SenderEmail = "MargaretPeacock@devexpress.com",
                    Subject = "Website Re-Design Plan",
                    Body = "The changes in our brochure designs for 2013 require us " +
                    "to update key areas of our website."
                }
            );
            MailMessages.Add(
                new MailData() {
                    SenderName = "Steven Buchanan",
                    SenderEmail = "StevenBuchanan@devexpress.com",
                    Subject = "Non-Compete Agreements",
                    Body = "Make final decision on whether our employees " +
                    "should sign non-compete agreements. " +
                    "Samantha Bright: Greta, we discussed this and we feel it is unnecessary " +
                    "to require non-compete agreements for employees."
                }
            );
            MailMessages.Add(
                new MailData() {
                    SenderName = "Michael Suyama",
                    SenderEmail = "MichaelSuyama@devexpress.com",
                    Subject = "Update Employee Files with New NDA",
                    Body = "Management has approved new NDA. " +
                    "All employees must sign the new NDA and their employee files must be updated. " +
                    "Greta Sims: Having difficulty with a few employees. Will follow up by Email."
                }
            );
            MailMessages.Add(
                new MailData() {
                    SenderName = "Robert King",
                    SenderEmail = "RobertKing@devexpress.com",
                    Subject = "Review Health Insurance Options Under the Affordable Care Act",
                    Body = "The changes in health insurance laws " +
                    "require that we review our existing coverage " +
                    "and update it to meet regulations. Samantha Bright will be point on this. " +
                    "Samantha Bright: " +
                    "Update - still working with the insurance company to update our coverages."
                }
            );
            MailMessages.Add(
                new MailData() {
                    SenderName = "Laura Callahan",
                    SenderEmail = "LauraCallahan@devexpress.com",
                    Subject = "Give Final Approval for Refunds",
                    Body = "Refunds as a result of our 2013 TV recalls have been submitted. " +
                    "Need final approval to cut checks to customers. " +
                    "Samantha Bright: You can send the checks out mid-May."
                }
            );
            MailMessages.Add(
                new MailData() {
                    SenderName = "Anne Dodsworth",
                    SenderEmail = "AnneDodsworth@devexpress.com",
                    Subject = "Decide on Mobile Devices to Use in the Field",
                    Body = "We need to decide whether we are going " +
                    "to use Surface tablets in the field or go with iPad. " +
                    "I have prepared the pros and cons based on feedback from everyone in the IT dept. " +
                    "Arthur Miller: Surface."
                }
            );
            GenerateRandomMailTime();
        }

        void GenerateRandomMailTime() {
            DateTime currentDate = DateTime.Now.Date.AddMinutes(-1 * this.random.Next(1, 560));
            foreach (MailData mail in MailMessages) {
                currentDate = currentDate.AddMinutes(-1 * this.random.Next(1, 200));
                mail.MailTime = currentDate;
            }
        }
    }
}
