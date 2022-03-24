using PropertyChanged;
using System.ComponentModel;

namespace NewStartTreeViews
{
    //[ImplementPropertyChanged]
    /*public class Class1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public string Test{ get; set; }
    */

        #region replace Nuget - fody
        /*
        private string mTest;
        public string Test 
        {
            get
            {
                return mTest;
            }
            set
            {
                if (mTest == value)
                    return;

                mTest = value;

                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Test)));
            }
        }

        public Class1()
        {
            Task.Run(async () =>
            {
                int i = 0;

                while (true)
                {
                    await Task.Delay(200);
                    Test = (i++).ToString();
                }
            }
            );
        }
        */
        #endregion

    //}
}
