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
            context.Descriptions.RemoveRange(context.Descriptions.ToList<Description>());
            context.Categories.RemoveRange(context.Categories.ToList<Category>());
            context.Questions.RemoveRange(context.Questions.ToList<Question>());

            Question ProjectWork = new Question()
                {
                    title = "Project Work",
                    categories = 
                    {
                        new Category()
                        {
                            name = "Quantity",
                            Descriptions =
                            {
                                new Description()
                                {
                                    Position = 1,
                                    Value = "Produced little or no work that will be part of the completed system."
                                },
                                new Description()
                                {
                                    Position = 2,
                                    Value = "Completed some useful work but less then their fair share."
                                },
                                new Description()
                                {
                                    Position = 3,
                                    Value = "Completed their fair share of work."
                                },
                                new Description()
                                {
                                    Position = 4,
                                    Value = "Completed more then their fair share of work. (If this is true but had a negative effect, that should be indicated in the comments and the scores for Relationships.)"
                                }
                            }
                        },
                        new Category()
                        {
                            name = "Quality",
                            Descriptions =
                            {
                                new Description()
                                {
                                    Position = 1,
                                    Value = "Little work was produced or very little of the work did not have to be reworked."
                                },
                                new Description()
                                {
                                    Position = 2,
                                    Value = "Some of the work that was produced as usable."
                                },
                                new Description()
                                {
                                    Position = 3,
                                    Value = "The majority of the work that was produced was usable."
                                },
                                new Description()
                                {
                                    Position = 4,
                                    Value = "The work was of a very high quality."
                                }
                            }
                        },
                        new Category()
                        {
                            name = "Timeliness",
                            Descriptions =
                            {
                                new Description()
                                {
                                    Position = 1,
                                    Value = "The work promised or scheduled was not produced on time."
                                },
                                new Description()
                                {
                                    Position = 2,
                                    Value = "Some of the work produced was not on time."
                                },
                                new Description()
                                {
                                    Position = 3,
                                    Value = "The work that was produced was generally on time."
                                },
                                new Description()
                                {
                                    Position = 4,
                                    Value = "The work was either on time or completed early."
                                }
                            }
                        }
                    }
                };
            Question Relationships = new Question()
                {
                    title = "Relationships",
                    categories = 
                    {
                        new Category()
                        {
                           name = "Respect",
                           Descriptions =
                           {
                               new Description()
                               {
                                   Position = 1,
                                   Value = "Needs assistance to demonstrate respect toward others."
                               },
                               new Description()
                               {
                                   Position = 2,
                                   Value = "Demonstrates respect for others."
                               },
                               new Description()
                               {
                                   Position = 3,
                                   Value = "Actively works to enhance respect for others."
                               },
                               new Description()
                               {
                                   Position = 4,
                                   Value = "Proactively anticipates."
                               }
                           }
                        },
                        new Category()
                        {
                           name = "Attitude",
                           Descriptions =
                           {
                               new Description()
                               {
                                   Position = 1,
                                   Value = "Exhibits a negative attitude."
                               },
                               new Description()
                               {
                                   Position = 2,
                                   Value = "Demonstrates and understands the importance of a positive attitude."
                               },
                               new Description()
                               {
                                   Position = 3,
                                   Value = "Actively enhances a positive attitude."
                               },
                               new Description()
                               {
                                   Position = 4,
                                   Value = "Proactively anticipates."
                               }
                           }
                        },
                        new Category()
                        {
                           name = "Teamwork",
                           Descriptions =
                           {
                               new Description()
                               {
                                   Position = 1,
                                   Value = "Struggles to work collaboratively with others."
                               },
                               new Description()
                               {
                                   Position = 2,
                                   Value = "Works collaboratively with others."
                               },
                               new Description()
                               {
                                   Position = 3,
                                   Value = "Works collaboratively and values the work of the team."
                               },
                               new Description()
                               {
                                   Position = 4,
                                   Value = "Proactively anticipates."
                               }
                           }
                        },
                        new Category()
                        {
                           name = "Conflict Resolution",
                           Descriptions =
                           {
                               new Description()
                               {
                                   Position = 1,
                                   Value = "Avoids or creates conflict"
                               },
                               new Description()
                               {
                                   Position = 2,
                                   Value = "Compromises on conflicting issues."
                               },
                               new Description()
                               {
                                   Position = 3,
                                   Value = "Strives to facilitate and reach a positive resolution."
                               },
                               new Description()
                               {
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
                    categories = 
                    {
                        new Category()
                        {
                           name = "Verbal",
                           Descriptions =
                           {
                               new Description()
                               {
                                   Position = 1,
                                   Value = "Needs assistance to speak in a logical, purposeful, organized, and well-supported manner using acceptable language."
                               },
                               new Description()
                               {
                                   Position = 2,
                                   Value = "Aware of ways to improve communication in a logical, purposeful, organized, and well-supported manner using acceptable language with effective use of voice."
                               },
                               new Description()
                               {
                                   Position = 3,
                                   Value = "Communicates in a logical, purposeful, organized, and well-supported manner using acceptable language with effective use of voice most of the time."
                               },
                               new Description()
                               {
                                   Position = 4,
                                   Value = "Communicates at a professional level which is logical, purposeful, organized, and well-supported using acceptable language with effective use of voice."
                               }
                           }
                        },
                        new Category()
                        {
                           name = "Non-verbal",
                           Descriptions =
                           {
                               new Description()
                               {
                                   Position = 1,
                                   Value = "Uses inappropriate non-verbal gestures, body language, or expressions."
                               },
                               new Description()
                               {
                                   Position = 2,
                                   Value = "Aware of the factors that contribute to acceptable and appropriate non-verbal communication."
                               },
                               new Description()
                               {
                                   Position = 3,
                                   Value = "Practices acceptable non-verbal communication using appropriate gestures, body language, and expressions most of the time."
                               },
                               new Description()
                               {
                                   Position = 4,
                                   Value = "Poses very professional non-verbal communication using appropriate gestures, body language, and expressions."
                               }
                           }
                        },
                        new Category()
                        {
                           name = "Listening",
                           Descriptions =
                           {
                               new Description()
                               {
                                   Position = 1,
                                   Value = "Lacks appropriate listening skills."
                               },
                               new Description()
                               {
                                   Position = 2,
                                   Value = "Aware of the skills necessary to be an intent and active listener."
                               },
                               new Description()
                               {
                                   Position = 3,
                                   Value = "Listens intently and can restate the message most of the time."
                               },
                               new Description()
                               {
                                   Position = 4,
                                   Value = "Poses exceptional listening skills by listening intently without interrupting and restating the message successfully."
                               }
                           }
                        },
                        new Category()
                        {
                           name = "Written",
                           Descriptions =
                           {
                               new Description()
                               {
                                   Position = 1,
                                   Value = "Writes in an unacceptable manner with many errors in grammar and standard written English."
                               },
                               new Description()
                               {
                                   Position = 2,
                                   Value = "Writes clearly enough to convey a message with some errors in grammar and standard written English."
                               },
                               new Description()
                               {
                                   Position = 3,
                                   Value = "Writes at an acceptable level to convey a clear message with minimal errors in grammar and standard written English."
                               },
                               new Description()
                               {
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
        }
    }
}
