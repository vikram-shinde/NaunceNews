using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NaunceNews.Core;
using NaunceNews.Core.Entities;

namespace NaunceNews.Publisher.Tests
{
    [TestClass]
    public class PublisherTests
    {
        readonly List<News> News = new List<News>() 
        {
            new News{ Priority = NewsPriority.High, Title = "NN: Political News Title 1", Description = "Political News Description 1", Category = Category.Political },
            new News{ Priority = NewsPriority.High, Title = "NN: Political News Title 1", Description = "Political News Description 1", Category = Category.Political },
            new News{ Priority = NewsPriority.High, Title = "NN: Political News Title 1", Description = "Political News Description 1", Category = Category.Political },
            new News{ Priority = NewsPriority.High, Title = "NN: Political News Title 1", Description = "Political News Description 1", Category = Category.Political },
            new News{ Priority = NewsPriority.High, Title = "NN: Political News Title 1", Description = "Political News Description 1", Category = Category.Political },
            new News{ Priority = NewsPriority.High, Title = "NN: Political News Title 1", Description = "Political News Description 1", Category = Category.Political },
            new News{ Priority = NewsPriority.High, Title = "NN: Political News Title 1", Description = "Political News Description 1", Category = Category.Political },
            new News{ Priority = NewsPriority.High, Title = "NN: Political News Title 1", Description = "Political News Description 1", Category = Category.Political },
            new News{ Priority = NewsPriority.Normal, Title = "NN: Political News Title 2", Description = "Political News Description 2", Category = Category.Political },
            new News{ Priority = NewsPriority.High, Title = "NN: Political News Title 3", Description = "Political News Description 3", Category = Category.Political },
            new News{ Priority = NewsPriority.Normal, Title = "NN: Sports News Title 1", Description = "Sports News Description 1", Category = Category.Sports },
            new News{ Priority = NewsPriority.High, Title = "NN: Sports News Title 2", Description = "Sports News Description 2", Category = Category.Sports },
            new News{ Priority = NewsPriority.Low, Title = "NN: Travel News Title 1", Description = "Travel News Description 1", Category = Category.Travel },
            new News{ Priority = NewsPriority.Low, Title = "NN: Travel News Title 1", Description = "Travel News Description 1", Category = Category.Travel },
            new News{ Priority = NewsPriority.Low, Title = "NN: Travel News Title 1", Description = "Travel News Description 1", Category = Category.Travel },
            new News{ Priority = NewsPriority.Low, Title = "NN: Travel News Title 1", Description = "Travel News Description 1", Category = Category.Travel },
            new News{ Priority = NewsPriority.Low, Title = "NN: Travel News Title 1", Description = "Travel News Description 1", Category = Category.Travel },
            new News{ Priority = NewsPriority.Low, Title = "NN: Travel News Title 1", Description = "Travel News Description 1", Category = Category.Travel },
            new News{ Priority = NewsPriority.Low, Title = "NN: Travel News Title 1", Description = "Travel News Description 1", Category = Category.Travel },
            new News{ Priority = NewsPriority.Low, Title = "NN: Travel News Title 1", Description = "Travel News Description 1", Category = Category.Travel },
            new News{ Priority = NewsPriority.Low, Title = "NN: Travel News Title 1", Description = "Travel News Description 1", Category = Category.Travel },
            new News{ Priority = NewsPriority.Low, Title = "NN: Travel News Title 1", Description = "Travel News Description 1", Category = Category.Travel },
            new News{ Priority = NewsPriority.Low, Title = "NN: Travel News Title 1", Description = "Travel News Description 1", Category = Category.Travel },
        };
        readonly List<Advertisement> Ads = new List<Advertisement>() 
        {
            new Advertisement{ Title = "NA: Advertisement Title 1", Description = "Advertisement Description 1"},
            new Advertisement{ Title = "NA: Advertisement Title 2", Description = "Advertisement Description 2"},
            new Advertisement{ Title = "NA: Advertisement Title 3", Description = "Advertisement Description 3"},
            new Advertisement{ Title = "NA: Advertisement Title 4", Description = "Advertisement Description 4"},
            new Advertisement{ Title = "NA: Advertisement Title 5", Description = "Advertisement Description 5"},
            new Advertisement{ Title = "NA: Advertisement Title 6", Description = "Advertisement Description 6"},
        };

        [TestMethod]
        public void Should_Publish_Empty_Sources()
        {
            var mockedNewsSources = new Mock<INewsSource>();
            mockedNewsSources.Setup(n => n.GetNews(NewsPriority.All)).Returns(new List<News>() { });

            var mockedAdSources = new Mock<IAdvertisementSource>();
            mockedAdSources.Setup(n => n.GetAds()).Returns(Ads);

            var mockedPublisherFactory = new Mock<IPublisherFactory>();
            mockedPublisherFactory.Setup(n => n.GetNewsSources()).Returns(new List<INewsSource> { mockedNewsSources.Object });
            mockedPublisherFactory.Setup(n => n.GetAdvertisementSources()).Returns(new List<IAdvertisementSource> { mockedAdSources.Object });

            var pages = new Publisher(mockedPublisherFactory.Object).Publish();

            Assert.IsNotNull(pages);
            Assert.AreEqual(0, pages.Count);
        }

        [TestMethod]
        public void Should_Publish_One_HighPriority_News()
        {
            var mockedNewsSources = new Mock<INewsSource>();
            var data = News.Where(n=>n.Priority == NewsPriority.High).Take(1).ToList();
            mockedNewsSources.Setup(n => n.GetNews(NewsPriority.All)).Returns(data);

            var mockedAdSources = new Mock<IAdvertisementSource>();
            mockedAdSources.Setup(n => n.GetAds()).Returns(Ads);

            var mockedPublisherFactory = new Mock<IPublisherFactory>();
            mockedPublisherFactory.Setup(n => n.GetNewsSources()).Returns(new List<INewsSource> { mockedNewsSources.Object });
            mockedPublisherFactory.Setup(n => n.GetAdvertisementSources()).Returns(new List<IAdvertisementSource> { mockedAdSources.Object });

            var pages = new Publisher(mockedPublisherFactory.Object).Publish();

            Assert.IsNotNull(pages);
            Assert.AreEqual(1, pages.Count);
            Assert.AreEqual(1, pages[0].News.Count);
            Assert.AreEqual(1, pages[0].News.Count(n => n.Priority == NewsPriority.High));
            Assert.AreEqual(2, pages[0].Ads.Count);
        }

        [TestMethod]
        public void Should_Publish_Six_HighPriority_News()
        {
            var mockedNewsSources = new Mock<INewsSource>();
            var data = News.Where(n => n.Priority == NewsPriority.High).Take(6).ToList();
            mockedNewsSources.Setup(n => n.GetNews(NewsPriority.All)).Returns(data);


            var mockedAdSources = new Mock<IAdvertisementSource>();
            mockedAdSources.Setup(n => n.GetAds()).Returns(Ads);

            var mockedPublisherFactory = new Mock<IPublisherFactory>();
            mockedPublisherFactory.Setup(n => n.GetNewsSources()).Returns(new List<INewsSource> { mockedNewsSources.Object });
            mockedPublisherFactory.Setup(n => n.GetAdvertisementSources()).Returns(new List<IAdvertisementSource> { mockedAdSources.Object });

            var pages = new Publisher(mockedPublisherFactory.Object).Publish();

            Assert.IsNotNull(pages);
            Assert.AreEqual(1, pages.Count);
            Assert.AreEqual(6, pages[0].News.Count);
            Assert.AreEqual(6, pages[0].News.Count(n=>n.Priority == NewsPriority.High));
            Assert.AreEqual(2, pages[0].Ads.Count);
        }

        [TestMethod]
        public void Should_Publish_Seven_HighPriority_News()
        {
            var mockedNewsSources = new Mock<INewsSource>();
            var data = News.Where(n => n.Priority == NewsPriority.High).Take(7).ToList();
            mockedNewsSources.Setup(n => n.GetNews(NewsPriority.All)).Returns(data);


            var mockedAdSources = new Mock<IAdvertisementSource>();
            mockedAdSources.Setup(n => n.GetAds()).Returns(Ads);

            var mockedPublisherFactory = new Mock<IPublisherFactory>();
            mockedPublisherFactory.Setup(n => n.GetNewsSources()).Returns(new List<INewsSource> { mockedNewsSources.Object });
            mockedPublisherFactory.Setup(n => n.GetAdvertisementSources()).Returns(new List<IAdvertisementSource> { mockedAdSources.Object });

            var pages = new Publisher(mockedPublisherFactory.Object).Publish();

            Assert.IsNotNull(pages);
            Assert.AreEqual(1, pages.Count);
            Assert.AreEqual(7, pages[0].News.Count);
            Assert.AreEqual(7, pages[0].News.Count(n => n.Priority == NewsPriority.High));
            Assert.AreEqual(1, pages[0].Ads.Count);
        }

        [TestMethod]
        public void Should_Publish_Eight_HighPriority_News()
        {
            var mockedNewsSources = new Mock<INewsSource>();
            var data = News.Where(n => n.Priority == NewsPriority.High).Take(8).ToList();
            mockedNewsSources.Setup(n => n.GetNews(NewsPriority.All)).Returns(data);


            var mockedAdSources = new Mock<IAdvertisementSource>();
            mockedAdSources.Setup(n => n.GetAds()).Returns(Ads);

            var mockedPublisherFactory = new Mock<IPublisherFactory>();
            mockedPublisherFactory.Setup(n => n.GetNewsSources()).Returns(new List<INewsSource> { mockedNewsSources.Object });
            mockedPublisherFactory.Setup(n => n.GetAdvertisementSources()).Returns(new List<IAdvertisementSource> { mockedAdSources.Object });

            var pages = new Publisher(mockedPublisherFactory.Object).Publish();

            Assert.IsNotNull(pages);
            Assert.AreEqual(1, pages.Count);
            Assert.AreEqual(8, pages[0].News.Count);
            Assert.AreEqual(8, pages[0].News.Count(n => n.Priority == NewsPriority.High));
            Assert.AreEqual(0, pages[0].Ads.Count);
        }

        [TestMethod]
        public void Should_Publish_Nine_HighPriority_News()
        {
            var mockedNewsSources = new Mock<INewsSource>();
            var data = News.Where(n => n.Priority == NewsPriority.High).Take(9).ToList();
            mockedNewsSources.Setup(n => n.GetNews(NewsPriority.All)).Returns(data);


            var mockedAdSources = new Mock<IAdvertisementSource>();
            mockedAdSources.Setup(n => n.GetAds()).Returns(Ads);

            var mockedPublisherFactory = new Mock<IPublisherFactory>();
            mockedPublisherFactory.Setup(n => n.GetNewsSources()).Returns(new List<INewsSource> { mockedNewsSources.Object });
            mockedPublisherFactory.Setup(n => n.GetAdvertisementSources()).Returns(new List<IAdvertisementSource> { mockedAdSources.Object });

            var pages = new Publisher(mockedPublisherFactory.Object).Publish();

            Assert.IsNotNull(pages);
            Assert.AreEqual(2, pages.Count);

            Assert.AreEqual(8, pages[0].News.Count);
            Assert.AreEqual(8, pages[0].News.Count(n => n.Priority == NewsPriority.High));
            Assert.AreEqual(0, pages[0].Ads.Count);

            Assert.AreEqual(1, pages[1].News.Count);
            Assert.AreEqual(1, pages[1].News.Count(n => n.Priority == NewsPriority.High));
            Assert.AreEqual(2, pages[1].Ads.Count);
        }

        [TestMethod]
        public void Should_Publish_No_HighPriority_Five_Other_News()
        {
            var mockedNewsSources = new Mock<INewsSource>();
            var data = News.Where(n => n.Priority == NewsPriority.High).Take(0).ToList();
            data.AddRange(News.Where(n => n.Priority != NewsPriority.High).Take(5).ToList());
            mockedNewsSources.Setup(n => n.GetNews(NewsPriority.All)).Returns(data);


            var mockedAdSources = new Mock<IAdvertisementSource>();
            mockedAdSources.Setup(n => n.GetAds()).Returns(Ads);

            var mockedPublisherFactory = new Mock<IPublisherFactory>();
            mockedPublisherFactory.Setup(n => n.GetNewsSources()).Returns(new List<INewsSource> { mockedNewsSources.Object });
            mockedPublisherFactory.Setup(n => n.GetAdvertisementSources()).Returns(new List<IAdvertisementSource> { mockedAdSources.Object });

            var pages = new Publisher(mockedPublisherFactory.Object).Publish();

            Assert.IsNotNull(pages);
            Assert.AreEqual(1, pages.Count);

            Assert.AreEqual(5, pages[0].News.Count);
            Assert.AreEqual(5, pages[0].News.Count(n => n.Priority != NewsPriority.High));
            Assert.AreEqual(2, pages[0].Ads.Count);
        }

        [TestMethod]
        public void Should_Publish_No_HighPriority_Ten_Other_News()
        {
            var mockedNewsSources = new Mock<INewsSource>();
            var data = News.Where(n => n.Priority == NewsPriority.High).Take(0).ToList();
            data.AddRange(News.Where(n => n.Priority != NewsPriority.High).Take(10).ToList());
            mockedNewsSources.Setup(n => n.GetNews(NewsPriority.All)).Returns(data);


            var mockedAdSources = new Mock<IAdvertisementSource>();
            mockedAdSources.Setup(n => n.GetAds()).Returns(Ads);

            var mockedPublisherFactory = new Mock<IPublisherFactory>();
            mockedPublisherFactory.Setup(n => n.GetNewsSources()).Returns(new List<INewsSource> { mockedNewsSources.Object });
            mockedPublisherFactory.Setup(n => n.GetAdvertisementSources()).Returns(new List<IAdvertisementSource> { mockedAdSources.Object });

            var pages = new Publisher(mockedPublisherFactory.Object).Publish();

            Assert.IsNotNull(pages);
            Assert.AreEqual(2, pages.Count);

            Assert.AreEqual(6, pages[0].News.Count);
            Assert.AreEqual(6, pages[0].News.Count(n => n.Priority != NewsPriority.High));
            Assert.AreEqual(2, pages[0].Ads.Count);

            Assert.AreEqual(4, pages[1].News.Count);
            Assert.AreEqual(4, pages[1].News.Count(n => n.Priority != NewsPriority.High));
            Assert.AreEqual(2, pages[1].Ads.Count);
        }

        [TestMethod]
        public void Should_Publish_Five_HighPriority_Ten_Other_News()
        {
            var mockedNewsSources = new Mock<INewsSource>();
            var data = News.Where(n => n.Priority == NewsPriority.High).Take(5).ToList();
            data.AddRange(News.Where(n => n.Priority != NewsPriority.High).Take(10).ToList());
            mockedNewsSources.Setup(n => n.GetNews(NewsPriority.All)).Returns(data);


            var mockedAdSources = new Mock<IAdvertisementSource>();
            mockedAdSources.Setup(n => n.GetAds()).Returns(Ads);

            var mockedPublisherFactory = new Mock<IPublisherFactory>();
            mockedPublisherFactory.Setup(n => n.GetNewsSources()).Returns(new List<INewsSource> { mockedNewsSources.Object });
            mockedPublisherFactory.Setup(n => n.GetAdvertisementSources()).Returns(new List<IAdvertisementSource> { mockedAdSources.Object });

            var pages = new Publisher(mockedPublisherFactory.Object).Publish();

            Assert.IsNotNull(pages);
            Assert.AreEqual(3, pages.Count);

            Assert.AreEqual(6, pages[0].News.Count);
            Assert.AreEqual(5, pages[0].News.Count(n => n.Priority == NewsPriority.High));
            Assert.AreEqual(1, pages[0].News.Count(n => n.Priority != NewsPriority.High));
            Assert.AreEqual(2, pages[0].Ads.Count);

            Assert.AreEqual(6, pages[1].News.Count);
            Assert.AreEqual(6, pages[1].News.Count(n => n.Priority != NewsPriority.High));
            Assert.AreEqual(2, pages[1].Ads.Count);

            Assert.AreEqual(3, pages[2].News.Count);
            Assert.AreEqual(3, pages[2].News.Count(n => n.Priority != NewsPriority.High));
            Assert.AreEqual(2, pages[2].Ads.Count);
        }
    }
}
