// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;
        [SetUp]
        public void SetUp()
        {
            stage = new Stage();
        }
        [Test]
        public void Test_Constructor_If_Instances_Correctly()
        {
            // cant test Songs count
            Assert.AreEqual(0, stage.Performers.Count);
        }
        [Test]
        public void Test_AddPerformer_If_Recieves_Null_Performer_Should_Throw_ArgumentNullException()
        {
            Performer performer = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddPerformer(performer);
            });
        }
        [Test]
        public void Test_AddPerformer_If_Recieves_Age_Less_Than_18_Should_Throw_ArgumentException()
        {
            Performer performer = new Performer("Chicho", "Koko", 12);
            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddPerformer(performer);
            });
        }
        [Test]
        public void Test_AddPerformer_If_Adds_Correctly_Should_Increase_Performers_Count()
        {
            Performer performer = new Performer("Chicho", "Koko", 40);
            stage.AddPerformer(performer);
            Assert.AreEqual(1, stage.Performers.Count);
        }
        [Test]
        public void Test_AddSong_If_Recieves_Null_Song_Should_Throw_ArgumentNullException()
        {
            Song song = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSong(song);
            });
        }
        [Test]
        public void Test_AddSong_If_Duration_Is_Less_Than_1_Minute_Should_Throw_ArgumentException()
        {
            Song song = new Song("HOP", new TimeSpan(0, 0, 30));
            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSong(song);
            });
        }
        [Test]
        public void Test_AddSongToPerformer_If_Recieves_Null_Song_Name_Should_Throw_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSongToPerformer(null, "Asd");
            });
        }
        [Test]
        public void Test_AddSongToPerformer_If_Recieves_Null_Performer_Name_Should_Throw_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSongToPerformer("Asd", null);
            });
        }
        [Test]
        public void Test_GetPerformer_Through_AddSongToPerformer_If_Recieves_Invalid_Name_Should_Throw_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSongToPerformer("peshkata", "goshkata");
            });
        }
         [Test]
        public void Test_GetSong_Through_AddSongToPerformer_If_Recieves_Invalid_Name_Should_Throw_ArgumentException()
        {
            Performer performer = new Performer("pesho", "goshkata", 25);
            stage.AddPerformer(performer);
            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSongToPerformer("peshkata", "pesho goshkata");
            });
        }
        [Test]
        public void Test_AddSongToPerformer_If_PerfomerSongList_Increases_Correctly()
        {
            Performer performer = new Performer("pesho", "goshkata", 25);
            Song song = new Song("MMA", new TimeSpan(0, 5, 30));
            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer("MMA", "pesho goshkata");
            Assert.AreEqual(1, performer.SongList.Count);
        }
        [Test]
        public void Test_AddSongToPerformer_If_Returns_Correct_string()
        {
            Performer performer = new Performer("pesho", "goshkata", 25);
            Song song = new Song("MMA", new TimeSpan(0, 5, 30));
            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer("MMA", "pesho goshkata");
            Assert.AreEqual($"{song} will be performed by {performer}", stage.AddSongToPerformer("MMA", "pesho goshkata"));
        }
        [Test]
        public void Test_If_Play_Works_Correctly()
        {
            Performer performer = new Performer("pesho", "goshkata", 25);
            Song song = new Song("MMA", new TimeSpan(0, 5, 30));
            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer("MMA", "pesho goshkata");
            Assert.AreEqual($"{stage.Performers.Count} performers played 1 songs", stage.Play());
        }
    }
}