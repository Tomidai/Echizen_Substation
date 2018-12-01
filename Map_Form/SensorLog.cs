using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace Map_Form {
    class SensorLog {
        //Map_Formのインスタンス
        public Map_Form mfObj;
        public Sensor snObj;
        public SensorAction snacObj;

        //コンストラクタ
        public SensorLog(Map_Form mf_obj) {
            mfObj = mf_obj;
            snObj = new Sensor(mfObj);
            snacObj = new SensorAction(mfObj);
        }

        private FileSystemWatcher Watcher;

        public void StartWatching() {
            //PLCから送られてくるファイルを監視するWatcherの定義
            Watcher = new FileSystemWatcher {
                Path = ConfigurationManager.AppSettings["WatchDir"],
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = "Logger.txt",
                IncludeSubdirectories = false
            };
            Watcher.Changed += Changed;
            Watcher.EnableRaisingEvents = true;
        }

        public void Changed(object source, FileSystemEventArgs e) {
            // ファイルストリームを開く
            var fs = File.OpenRead(@"J:\本社技術部\【技術本部共通】\test\Logger.txt");
            // 先ほどのファイルストリームを元に、Shift-JISのテキストを読み込むストリームを作成
            var sr = new StreamReader(fs, Encoding.GetEncoding("Shift_JIS"));

            // ファイルの中間の場所にシーク
            long pos = fs.Length;
            fs.Seek(pos, SeekOrigin.End);
            // シークした位置から一行読み込む
            string line = sr.ReadLine();

            Console.WriteLine(line);
            fs.Close();
            sr.Close();
        }
    }
}
