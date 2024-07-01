using OTUS.HW5.interfaces;

namespace OTUS.HW5
{
    public class FileSearcher : IFileSearcher
    {
        public event EventHandler<FileArgs> FileFound;

        private bool _cancelSearch;

        public void Search(string directory)
        {
            _cancelSearch = false;
            SearchDirectory(directory);
        }

        private void SearchDirectory(string directory)
        {
            if (_cancelSearch) return;

            try
            {
                foreach (var file in Directory.GetFiles(directory))
                {
                    OnFileFound(new FileArgs(file));
                    if (_cancelSearch) return;
                }

                foreach (var subDir in Directory.GetDirectories(directory))
                {
                    SearchDirectory(subDir);
                    if (_cancelSearch) return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка доступа к каталогу {directory}: {ex.Message}");
            }
        }

        protected virtual void OnFileFound(FileArgs e)
        {
            FileFound?.Invoke(this, e);
        }

        public void CancelSearch()
        {
            _cancelSearch = true;
        }
    }
}
