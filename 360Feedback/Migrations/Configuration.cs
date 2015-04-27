namespace _360Feedback.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using _360Feedback.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<_360Feedback.DataContexts.FeedbackDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_360Feedback.DataContexts.FeedbackDb context)
        {
            Question ProjectWork = new Question()
                {
                    title = "Project Work",
                    QuestionId = 1,
                };
            Question Relationships = new Question()
                {
                    title = "Relationships",
                    QuestionId = 2,
                    categories = 
                    {
                        new Category()
                        {
                           CategoryId = 4,
                           name = "Respect",
                           Descriptions =
                           {
                               new Description()
                               {
                                   DescriptionId = 33,
                                   Position = 1,
                                   Value = "Needs assistance to demonstrate respect toward others."
                               },
                               new Description()
                               {
                                   DescriptionId = 34,
                                   Position = 2,
                                   Value = "Demonstrates respect for others."
                               },
                               new Description()
                               {
                                   DescriptionId = 35,
                                   Position = 3,
                                   Value = "Actively works to enhance respect for others."
                               },
                               new Description()
                               {
                                   DescriptionId = 36,
                                   Position = 4,
                                   Value = "Proactively anticipates."
                               }
                           }
                        },
                        new Category()
                        {
                           CategoryId = 5,
                           name = "Attitude",
                           Descriptions =
                           {
                               new Description()
                               {
                                   DescriptionId = 37,
                                   Position = 1,
                                   Value = "Exhibits a negative attitude."
                               },
                               new Description()
                               {
                                   DescriptionId = 38,
                                   Position = 2,
                                   Value = "Demonstrates and understands the importance of a positive attitude."
                               },
                               new Description()
                               {
                                   DescriptionId = 39,
                                   Position = 3,
                                   Value = "Actively enhances a positive attitude."
                               },
                               new Description()
                               {
                                   DescriptionId = 40,
                                   Position = 4,
                                   Value = "Proactively anticipates."
                               }
                           }
                        },
                        new Category()
                        {
                           CategoryId = 6,
                           name = "Teamwork",
                           Descriptions =
                           {
                               new Description()
                               {
                                   DescriptionId = 41,
                                   Position = 1,
                                   Value = "Struggles to work collaboratively with others."
                               },
                               new Description()
                               {
                                   DescriptionId = 42,
                                   Position = 2,
                                   Value = "Works collaboratively with others."
                               },
                               new Description()
                               {
                                   DescriptionId = 43,
                                   Position = 3,
                                   Value = "Works collaboratively and values the work of the team."
                               },
                               new Description()
                               {
                                   DescriptionId = 44,
                                   Position = 4,
                                   Value = "Proactively anticipates."
                               }
                           }
                        },
                        new Category()
                        {
                           CategoryId = 7,
                           name = "Conflict Resolution",
                           Descriptions =
                           {
                               new Description()
                               {
                                   DescriptionId = 13,
                                   Position = 1,
                                   Value = "Avoids or creates conflict"
                               },
                               new Description()
                               {
                                   DescriptionId = 14,
                                   Position = 2,
                                   Value = "Compromises on conflicting issues."
                               },
                               new Description()
                               {
                                   DescriptionId = 15,
                                   Position = 3,
                                   Value = "Strives to facilitate and reach a positive resolution."
                               },
                               new Description()
                               {
                                   DescriptionId = 16,
                                   Position = 4,
                                   Value = "Proactively anticipates."
                               }
                           }
                        }
                    }
                };
            Question Communication = new Question()
                {
                    title = "Communication",
                    QuestionId = 3,
                    categories = 
                    {
                        new Category()
                        {
                           CategoryId = 8,
                           name = "Verbal",
                           Descriptions =
                           {
                               new Description()
                               {
                                   DescriptionId = 17,
                                   Position = 1,
                                   Value = "Needs assistance to speak in a logical, purposeful, organized, and well-supported manner using acceptable language."
                               },
                               new Description()
                               {
                                   DescriptionId = 18,
                                   Position = 2,
                                   Value = "Aware of ways to improve communication in a logical, purposeful, organized, and well-supported manner using acceptable language with effective use of voice."
                               },
                               new Description()
                               {
                                   DescriptionId = 19,
                                   Position = 3,
                                   Value = "Communicates in a logical, purposeful, organized, and well-supported manner using acceptable language with effective use of voice most of the time."
                               },
                               new Description()
                               {
                                   DescriptionId = 20,
                                   Position = 4,
                                   Value = "Communicates at a professional level which is logical, purposeful, organized, and well-supported using acceptable language with effective use of voice."
                               }
                           }
                        },
                        new Category()
                        {
                           CategoryId = 9,
                           name = "Non-verbal",
                           Descriptions =
                           {
                               new Description()
                               {
                                   DescriptionId = 21,
                                   Position = 1,
                                   Value = "Uses inappropriate non-verbal gestures, body language, or expressions."
                               },
                               new Description()
                               {
                                   DescriptionId = 22,
                                   Position = 2,
                                   Value = "Aware of the factors that contribute to acceptable and appropriate non-verbal communication."
                               },
                               new Description()
                               {
                                   DescriptionId = 23,
                                   Position = 3,
                                   Value = "Practices acceptable non-verbal communication using appropriate gestures, body language, and expressions most of the time."
                               },
                               new Description()
                               {
                                   DescriptionId = 24,
                                   Position = 4,
                                   Value = "Poses very professional non-verbal communication using appropriate gestures, body language, and expressions."
                               }
                           }
                        },
                        new Category()
                        {
                           CategoryId = 10,
                           name = "Listening",
                           Descriptions =
                           {
                               new Description()
                               {
                                   DescriptionId = 25,
                                   Position = 1,
                                   Value = "Lacks appropriate listening skills."
                               },
                               new Description()
                               {
                                   DescriptionId = 26,
                                   Position = 2,
                                   Value = "Aware of the skills necessary to be an intent and active listener."
                               },
                               new Description()
                               {
                                   DescriptionId = 27,
                                   Position = 3,
                                   Value = "Listens intently and can restate the message most of the time."
                               },
                               new Description()
                               {
                                   DescriptionId = 28,
                                   Position = 4,
                                   Value = "Poses exceptional listening skills by listening intently without interrupting and restating the message successfully."
                               }
                           }
                        },
                        new Category()
                        {
                           CategoryId = 11,
                           name = "Listening",
                           Descriptions =
                           {
                               new Description()
                               {
                                   DescriptionId = 29,
                                   Position = 1,
                                   Value = "Writes in an unacceptable manner with many errors in grammar and standard written English."
                               },
                               new Description()
                               {
                                   DescriptionId = 30,
                                   Position = 2,
                                   Value = "Writes clearly enough to convey a message with some errors in grammar and standard written English."
                               },
                               new Description()
                               {
                                   DescriptionId = 31,
                                   Position = 3,
                                   Value = "Writes at an acceptable level to convey a clear message with minimal errors in grammar and standard written English."
                               },
                               new Description()
                               {
                                   DescriptionId = 32,
                                   Position = 4,
                                   Value = "Writes in a professional manner which is clear and concise with no errors in grammar and standard written English."
                               }
                           }
                        }
                    }
                };
            context.Questions.AddOrUpdate<Question>(
                q => q.QuestionId,
                ProjectWork,
                Relationships,
                Communication
            );
            context.SaveChanges();

            Category Quantity = new Category()
            {
                CategoryId = 1,
                name = "Quantity",
                Question = ProjectWork
            };
            Category Quality = new Category()
            {
                CategoryId = 2,
                name = "Quality",
                Question = ProjectWork
            };
            Category Timeliness = new Category()
            {
                CategoryId = 3,
                name = "Timeliness",
                Question = ProjectWork
            };

            context.Categories.AddOrUpdate<Category>(
                c => c.CategoryId,
                Quantity,
                Quality,
                Timeliness
                );
            context.SaveChanges();

            Description QuantityOne = new Description()
            {
                DescriptionId = 1,
                Position = 1,
                Value = "Produced little or no work that will be part of the completed system.",
                Category = Quantity
            };
            Description QuantityTwo = new Description()
            {
                DescriptionId = 2,
                Position = 2,
                Value = "Completed some useful work but less then their fair share.",
                Category = Quantity
            };
            Description QuantityThree = new Description()
            {
                DescriptionId = 3,
                Position = 3,
                Value = "Completed their fair share of work.",
                Category = Quantity
            };
            Description QuantityFour = new Description()
            {
                DescriptionId = 4,
                Position = 4,
                Value = "Completed more then their fair share of work. (If this is true but had a negative effect, that should be indicated in the comments and the scores for Relationships.)",
                Category = Quantity
            };
            Description QualityOne = new Description()
            {
                DescriptionId = 5,
                Position = 1,
                Value = "Little work was produced or very little of the work did not have to be reworked.",
                Category = Quality
            };
            Description QualityTwo = new Description()
            {
                DescriptionId = 6,
                Position = 2,
                Value = "Some of the work that was produced as usable.",
                Category = Quality
            };
            Description QualityThree = new Description()
            {
                DescriptionId = 7,
                Position = 3,
                Value = "The majority of the work that was produced was usable.",
                Category = Quality
            };
            Description QualityFour = new Description()
            {
                DescriptionId = 8,
                Position = 4,
                Value = "The work was of a very high quality.",
                Category = Quality
            };
            Description TimelinessOne = new Description()
            {
                DescriptionId = 9,
                Position = 1,
                Value = "The work promised or scheduled was not produced on time.",
                Category = Timeliness
            };
            Description TimelinessTwo = new Description()
            {
                DescriptionId = 10,
                Position = 2,
                Value = "Some of the work produced was not on time.",
                Category = Timeliness
            };
            Description TimelinessThree = new Description()
            {
                DescriptionId = 11,
                Position = 3,
                Value = "The work that was produced was generally on time.",
                Category = Timeliness
            };
            Description TimelinessFour = new Description()
            {
                DescriptionId = 12,
                Position = 4,
                Value = "The work was either on time or completed early.",
                Category = Timeliness
            };

            context.Descriptions.AddOrUpdate<Description>(
                d => d.DescriptionId,
                QuantityOne,
                QuantityTwo,
                QuantityThree,
                QuantityFour,
                QualityOne,
                QualityTwo,
                QualityThree,
                QualityFour,
                TimelinessOne,
                TimelinessTwo,
                TimelinessThree,
                TimelinessFour
                );
        }
    }
}
