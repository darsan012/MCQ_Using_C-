// This class is used to save the questions to the database

using System;
using MCQAssignment3.Models;

namespace MCQAssignment3.Data
{
	public class Quizzes
	{
		public static void Seed(QuizContext context)
		{
			if (!context.Questions.Any())
			{
				context.Questions.AddRange(
					new Question { Text = "What is cloud computing?", Options = new[] { "Storing data on local servers", "Accessing computing resources over the internet", "Running software locally", "None of the above" }, CorrectOption = 1 },
					new Question { Text = "Which of the following is a cloud service model?", Options = new[] { "IaaS", "PaaS", "SaaS", "All of the above" }, CorrectOption = 3 },
					new Question { Text = "What does SaaS stand for?", Options = new[] { "Software as a Service", "Storage as a Service", "Security as a Service", "Server as a Service" }, CorrectOption = 0 },
					new Question { Text = "Which cloud provider is known for its 'EC2' service?", Options = new[] { "Amazon Web Services", "Microsoft Azure", "Google Cloud Platform", "IBM Cloud" }, CorrectOption = 0 },
					new Question { Text = "What is the primary advantage of cloud computing?", Options = new[] { "Cost reduction", "Data security", "Limited resources", "Better internet speed" }, CorrectOption = 0 },
					new Question { Text = "Which of the following is an example of IaaS?", Options = new[] { "AWS EC2", "Google App Engine", "Microsoft Office 365", "Salesforce" }, CorrectOption = 0 },
					new Question { Text = "Which company offers the Azure cloud platform?", Options = new[] { "Amazon", "Microsoft", "Google", "IBM" }, CorrectOption = 1 },
					new Question { Text = "Which of the following is an example of PaaS?", Options = new[] { "AWS EC2", "Google App Engine", "Dropbox", "None of the above" }, CorrectOption = 1 },
					new Question { Text = "What is a virtual machine in cloud computing?", Options = new[] { "A physical server", "A software-based simulation of a physical machine", "A type of cloud storage", "A programming language" }, CorrectOption = 1 },
					new Question { Text = "What does IaaS stand for?", Options = new[] { "Infrastructure as a Service", "Internet as a Service", "Integrated as a Service", "Information as a Service" }, CorrectOption = 0 },
					new Question { Text = "Which of the following is a key characteristic of cloud computing?", Options = new[] { "On-demand self-service", "Fixed capacity", "High upfront cost", "All of the above" }, CorrectOption = 0 },
					new Question { Text = "What does the 'elasticity' of cloud computing refer to?", Options = new[] { "Ability to run software on various devices", "Ability to scale resources up or down based on demand", "Ability to store infinite data", "None of the above" }, CorrectOption = 1 },
					new Question { Text = "What is a public cloud?", Options = new[] { "A cloud used by a single organization", "A cloud used by multiple organizations", "A private network for cloud services", "A type of cloud for storing files" }, CorrectOption = 1 },
					new Question { Text = "What does a cloud service provider offer?", Options = new[] { "Infrastructure", "Platform", "Software", "All of the above" }, CorrectOption = 3 },
					new Question { Text = "Which of the following is a disadvantage of cloud computing?", Options = new[] { "Cost efficiency", "High security", "Dependence on internet connectivity", "Ease of scaling" }, CorrectOption = 2 },
					new Question { Text = "What is a hybrid cloud?", Options = new[] { "A cloud for private use", "A cloud that uses both public and private services", "A type of cloud used by startups", "A cloud only for large enterprises" }, CorrectOption = 1 },
					new Question { Text = "What is the main purpose of cloud storage?", Options = new[] { "Storing files on physical hard drives", "Storing files on remote servers accessible via the internet", "Storing files on a local network", "None of the above" }, CorrectOption = 1 },
					new Question { Text = "Which of the following is a cloud computing security concern?", Options = new[] { "Data privacy", "Data loss", "Data breaches", "All of the above" }, CorrectOption = 3 },
					new Question { Text = "Which of the following is an example of cloud storage?", Options = new[] { "Dropbox", "OneDrive", "Google Drive", "All of the above" }, CorrectOption = 3 },
					new Question { Text = "What is the function of a cloud load balancer?", Options = new[] { "Distribute traffic across multiple servers", "Store data in the cloud", "Encrypt cloud data", "Run virtual machines" }, CorrectOption = 0 }
					);
				context.SaveChanges();
            }
		}
	}
}

