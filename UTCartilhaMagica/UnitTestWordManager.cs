using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UTCartilhaMagica
{
    [TestClass]
    public class UnitTestWordManager
    {
        CartilhaMagica.Manager.WordManager wm = new CartilhaMagica.Manager.WordManager();

        [TestMethod]
        public void TestMethod_GetSyllables()
        {
            var syllables = wm.GetSyllables("r", "tr", "pr");
            Assert.IsNotNull(syllables);
        }

        [TestMethod]
        public void TestMethod_GetLessons()
        {
            var letters = new string[] { "r", "tr", "pr", "z" };
            var lessons = wm.GetLessons(letters);
            Assert.IsTrue(lessons.Count == 4);
        }


        [TestMethod]
        public void Test_SaveSyllableState()
        {
            var syllables = wm.GetSyllables();

            int index = new Random().Next(1, syllables.Count - 1);
            wm.SaveCurrentSyllableState(syllables, index);

            var syllables2 = wm.GetCurrentSyllableState(out int index2);

            Assert.IsTrue(index == index2 && syllables2.Count == syllables.Count);
        }


        [TestMethod]
        public void Test_SaveWordState()
        {
            var words = wm.GetWords(CartilhaMagica.Manager.Level.Average, true);

            int index = new Random().Next(1, words.Length - 1);
            wm.SaveCurrentWordState(words, index, 2);

            var words2 = wm.GetCurrentWordState(out int index2, out byte level);

            Assert.IsTrue(index == index2 && words.Length == words2.Length);
        }
    }
}
