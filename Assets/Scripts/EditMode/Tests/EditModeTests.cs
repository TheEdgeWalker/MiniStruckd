using EditMode;
using NUnit.Framework;

namespace Tests
{
    public class EditModeTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CommmandManagerTests()
        {
            // Use the Assert class to test conditions
            CommandManager commandManager = new CommandManager(3);
            
            // CommandManager is empty 
            Assert.IsTrue(commandManager.Count == 0);
            
            // Pop while empty
            commandManager.UndoAndPop();
        }
    }
}
