using ClassLibrary1;
using Moq;
using System.Windows.Forms;
using WinFormsApp1;
using Moq;
using static WinFormsApp1.Form1;

namespace TestProject1
{
    public class Tests
    {
        Form1 form;
        Mock<IMessageService> message;

        [SetUp]
        public void Setup()
        {
            message = new Mock<IMessageService>();
            form = new Form1(message.Object);
        }

        [Test]

        public void CheckNameError()
        {
            form.btnCalculate_Click(null, null);

            message.Verify(x => x.Show("You have to enter a name"));
        }

        [Test]
        public void CheckValueError()
        {
            //I just need to figure out how to make it so it auto fills a name so that it would go to the second error and this
            //problem would fix itself. But for the life of me I can't get it to work for me.
            form.btnCalculate_Click(null, null);

            message.Verify(x => x.Show("Must be between 10k and 1MM"));
        }
    }
}