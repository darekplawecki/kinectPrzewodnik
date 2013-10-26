using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Przewodnik.Models
{
    class SleepScreenModel
    {
        public List<Image> CurrentImages { get; set; }

        public SleepScreenModel()
        {
            CurrentImages = new List<Image>(6);
        }

        //private Image currentImage1;
        //private Image currentImage2;
        //private Image currentImage3;
        //private Image currentImage4;
        //private Image currentImage5;
        //private Image currentImage6;

        //public Image CurrentImage1
        //{
        //    get
        //    {
        //        return this.currentImage1;
        //    }

        //    set
        //    {
        //        this.currentImage1 = value;
        //    }
        //}

        //public Image CurrentImage2
        //{
        //    get
        //    {
        //        return this.currentImage2;
        //    }

        //    set
        //    {
        //        this.currentImage2 = value;
        //    }
        //}

        //public Image CurrentImage3
        //{
        //    get
        //    {
        //        return this.currentImage3;
        //    }

        //    set
        //    {
        //        this.currentImage3 = value;
        //    }
        //}

        //public Image CurrentImage4
        //{
        //    get
        //    {
        //        return this.currentImage4;
        //    }

        //    set
        //    {
        //        this.currentImage4 = value;
        //    }
        //}

        //public Image CurrentImage5
        //{
        //    get
        //    {
        //        return this.currentImage5;
        //    }

        //    set
        //    {
        //        this.currentImage5 = value;
        //    }
        //}

        //public Image CurrentImage6
        //{
        //    get
        //    {
        //        return this.currentImage6;
        //    }

        //    set
        //    {
        //        this.currentImage6 = value;
        //    }
        //}
    }
}
