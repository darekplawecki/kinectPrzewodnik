using System;
using System.ComponentModel.Composition.Hosting;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows;
using Przewodnik.Utilities;

namespace Przewodnik
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IDisposable
    {
        public CultureInfo culture = new CultureInfo("pl-PL");
        public ResourceManager Rm = new ResourceManager("Przewodnik.Content.Translations.Translation", Assembly.GetExecutingAssembly());

        private bool disposed = false;

        /// <summary>
        /// Catalog of exported parts from an assembly
        /// </summary>
        private AssemblyCatalog catalog;

        /// <summary>
        /// Managed Entity Framework composition container used to compose the entity graph
        /// </summary>
        private CompositionContainer compositionContainer;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.catalog.Dispose();
                    this.compositionContainer.Dispose();
                }
            }

            this.disposed = true;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Catalog all exported parts within this assembly
            this.catalog = new AssemblyCatalog(typeof(App).Assembly);
            this.compositionContainer = new CompositionContainer(this.catalog);

            Window window = new MainWindow(this.compositionContainer.GetExportedValue<KinectController>());
            window.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            this.Dispose();
        }
    }
}
