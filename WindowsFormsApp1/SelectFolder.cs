using System;
using System.Windows.Forms;

namespace ClaymoreBatcher
{
    public partial class SelectFolder : Form
    {
 
        public string MyPath { get; set; }

        public SelectFolder()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                #region parameters
                var items = new[]
                {
                    new Parameter("epool",
                        "Ethereum pool address. Only Stratum protocol is supported for pools. Miner supports all pools that are compatible with Dwarfpool proxy and accept Ethereum wallet address directly. For solo mining, specify 'http://' before address, note that this mode is not intended for proxy or HTTP pools, also '-allpools 1' will be set automatically in this mode. Note: The miner supports all Stratum versions for Ethereum, HTTP mode is necessary for solo mining only. Using any proxies will reduce effective hashrate by at least 1%, so connect miner to Stratum pools directly. Using HTTP pools will reduce effective hashrate by at least 5%. Miner also supports SSL/TLS encryption for all data between miner and pool (if pool supports encryption over stratum), it significantly improves security. To enable encryption, use 'ssl://' or 'stratum+ssl://' prefix (or 'tls' instead of 'ssl'), for example: '-epool ssl://eu1.ethermine.org:5555'"),
                    new Parameter("ewal",
                        "Your Ethereum wallet address. Also worker name and other options if pool supports it. Pools that require 'Login.Worker' instead of wallet address are not supported directly currently, but you can use '-allpools 1' option to mine there."),
                    new Parameter("esm",
                        "Ethereum Stratum mode. 0 - eth-proxy mode (for example, dwarpool.com), 1 - qtminer mode (for example, ethpool.org), 2 - miner-proxy mode (for example, coinotron.com), 3 - nicehash mode. 0 is default.",
                        "1234"),
                    new Parameter("allcoins","'-allcoins 1' to be able to mine Ethereum forks, in this mode miner will use some default pools for devfee Ethereum mining. Note that if devfee mining pools will stop, entire mining will be stopped too. Miner has to use two DAGs in this mode - one for Ethereum and one for Ethereum fork, it can cause crashes because DAGs have different sizes. Therefore for this mode it is recommended to specify current Ethereum epoch (or a bit larger value), for example, '-allcoins 47' means that miner will expect DAG size for epoch #47 and will allocate appropriate GPU buffer at starting, instead of reallocating bigger GPU buffer (may crash) when it starts devfee mining. Another option is to specify '-allcoins -1', in this mode miner will start devfee round immediately after start and therefore will get current epoch for Ethereum, after that it will be able to mine Ethereum fork. If you mine ETC on some pool that does not accept wallet address but requires Username.Worker instead, the best way is to specify '-allcoins etc', in this mode devfee mining will be on ETC pools and DAG won't be recreated at all.", "Numbers" ),
                };
                #endregion parameters

                if (folderDialog.ShowDialog() != DialogResult.OK) return;
                MyPath = folderDialog.SelectedPath;
             
                var form1 = new Configurator(MyPath, items);
                Hide();
                form1.ShowDialog();
            }
        }
    }
}
