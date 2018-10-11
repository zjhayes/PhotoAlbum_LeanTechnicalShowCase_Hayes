using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum;
using PhotoAlbumUnitTests.Mocks;

namespace PhotoAlbumUnitTests
{
    [TestClass]
    public class EntryPointUnitTests
    {
        MockUserInput testInput = new MockUserInput();

        [TestMethod]
        public void RunByCommandLine_DeserializeAlbum_MethodRan_IsTrue()
        {
            EntryPoint testProgram = new EntryPoint();
            MockDeserializer mockDeserializer = new MockDeserializer();
            testProgram.Deserializer = mockDeserializer;
            testProgram.RunByCommandLine("1");
            bool actual = mockDeserializer.DeserializeAlbum_MethodRan;
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void RunByCommandLine_DeserializeAll_MethodRan_IsTrue()
        {
            EntryPoint testProgram = new EntryPoint();
            MockDeserializer mockDeserializer = new MockDeserializer();
            testProgram.Deserializer = mockDeserializer;
            testProgram.RunByCommandLine("all");
            bool actual = mockDeserializer.DeserializeAll_MethodRan;
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void RunByCommandLine_DeserializeJson_MethodRan_IsTrue()
        {
            EntryPoint testProgram = new EntryPoint();
            MockDeserializer mockDeserializer = new MockDeserializer();
            testProgram.Deserializer = mockDeserializer;
            testProgram.RunByCommandLine("1");
            bool actual = mockDeserializer.DeserializeJson_MethodRan;
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void RunByConsole_DeserializeAlbum_MethodRan_IsTrue()
        {
            EntryPointLoopOnce testProgramExits = new EntryPointLoopOnce();
            MockDeserializer mockDeserializer = new MockDeserializer();
            testProgramExits.Deserializer = mockDeserializer;
            testInput.SetTestInput("1");
            testProgramExits.RunByConsole(testInput);
            bool actual = mockDeserializer.DeserializeAlbum_MethodRan;
            Assert.IsTrue(actual);
        }
        
        [TestMethod]
        public void RunByConsole_DeserializeAll_MethodRan_IsTrue()
        {
            EntryPointLoopOnce testProgramExits = new EntryPointLoopOnce();
            MockDeserializer mockDeserializer = new MockDeserializer();
            testProgramExits.Deserializer = mockDeserializer;
            testInput.SetTestInput("all");
            testProgramExits.RunByConsole(testInput);
            bool actual = mockDeserializer.DeserializeAll_MethodRan;
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void RunByConsole_DeserializeJson_MethodRan_IsTrue()
        {
            EntryPointLoopOnce testProgramExits = new EntryPointLoopOnce();
            MockDeserializer mockDeserializer = new MockDeserializer();
            testProgramExits.Deserializer = mockDeserializer;
            testInput.SetTestInput("1");
            testProgramExits.RunByConsole(testInput);
            bool actual = mockDeserializer.DeserializeJson_MethodRan;
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void RunByConsole_InvalidInput_ThrowsException()
        {
            EntryPointLoopOnce testProgramExits = new EntryPointLoopOnce();
            MockDeserializer mockDeserializer = new MockDeserializer();
            testProgramExits.Deserializer = mockDeserializer;
            testInput.SetTestInput("foo"); // Invalid input.
            bool exceptionThrown = false;
            try
            {
                testProgramExits.RunByConsole(testInput);
                Assert.Fail();  // Exception not thrown if reached.
            }
            catch (Exception)
            {
                exceptionThrown = true;
                Assert.IsTrue(exceptionThrown);
            }
        }

        [TestMethod]
        public void RunByConsole_UserExits_IsExited_IsTrue()
        {
            EntryPoint testProgram = new EntryPoint();
            MockDeserializer mockDeserializer = new MockDeserializer();
            testProgram.Deserializer = mockDeserializer;
            testInput.SetTestInput("exit");
            testProgram.RunByConsole(testInput);
            Assert.IsTrue(testProgram.IsExited());
        }

        [TestMethod]
        public void RunByConsole_UserExits_DeserializeJsonMethodRan_IsFalse()
        {
            EntryPoint testProgram = new EntryPoint();
            MockDeserializer mockDeserializer = new MockDeserializer();
            testProgram.Deserializer = mockDeserializer;
            testInput.SetTestInput("exit");
            testProgram.RunByConsole(testInput);
            Assert.IsFalse(mockDeserializer.DeserializeJson_MethodRan);
        }
    }
}
