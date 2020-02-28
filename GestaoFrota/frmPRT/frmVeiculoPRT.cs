using GestaoFrota.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GestaoFrota.Models;
using System.Diagnostics;
using FIPE;
using CFSqlCe.Dal;
using System.IO;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestaoFrota
{
    public partial class frmVeiculoPRT : Form
    {
        #region Declarações

        Veiculo veiculo;
        Veiculo copiaVeiculo;
        DateTime dataInicialAtual;
        DateTime dataFinalAtual;
        DateTime dataAtual;
        DateTime dataInicialdoAno;
        DateTime dataFinaldoAno;
        ManutencaoBLL manutencaoBLL = ManutencaoBLL.Instancia;
        MultaBLL multaBLL = MultaBLL.Instancia;
        AbastecimentoBLL abastecimentoBLL = AbastecimentoBLL.Instancia;
        PagamentoDocumentoBLL pagamentoDocumentoBLL = PagamentoDocumentoBLL.Instancia;
        ContratoSeguradoraBLL contratoSeguradoraBLL = ContratoSeguradoraBLL.Instancia;
        VeiculoBLL veiculoBLL = VeiculoBLL.Instancia;
        MecanicaBLL mecanicaBLL = MecanicaBLL.Instancia;
        CombustivelBLL combustivelBLL = CombustivelBLL.Instancia;
        SeguradoraBLL seguradoraBLL = SeguradoraBLL.Instancia;
        List<TipoFIPEinfo> tiposFIPE = new List<TipoFIPEinfo>();
        List<MarcaFIPEinfo> marcasFIPE = new List<MarcaFIPEinfo>();
        List<CarroFIPEinfo> carrosFIPE = new List<CarroFIPEinfo>();
        List<CarroAnoFIPEinfo> carrosAnoFIPE = new List<CarroAnoFIPEinfo>();
        List<DGridSeguradoraInfo> seguradoras = new List<DGridSeguradoraInfo>();
        graficoPizzaInfo graficoPizzaAnual = new graficoPizzaInfo();
        Manutencao manutencaoVisualizacao;
        string pathOrigemComprovante = string.Empty;
        string pathOrigemOrcamentoSeguro = string.Empty;
        string pathOrigemCartaoSeguro = string.Empty;
        string pathDestinoComprovante = string.Empty;
        string pathDestinoOrcamentoSeguro = string.Empty;
        string pathDestinoCartaoSeguro = string.Empty;
        string fileNameComprovante = string.Empty;
        string fileNameOrcamentoSeguro = string.Empty;
        string fileNameCartaoSeguro = string.Empty;
        string pathOrigemMulta = string.Empty;
        string pathDestinoMulta = string.Empty;
        string fileNameMulta = string.Empty;
        string pathComprovante = Path.Combine(Environment.CurrentDirectory, "Comprovantes");
        string pathDocumentos = Path.Combine(Environment.CurrentDirectory, "Documentos");
        string pathSeguro = Path.Combine(Environment.CurrentDirectory, "Seguros");
        string pathMultas = Path.Combine(Environment.CurrentDirectory, "Multas");

        ContratoSeguro contratoSeguro;

        #endregion

        #region Construtores

        public frmVeiculoPRT()
        {
            InitializeComponent();
        }

        public frmVeiculoPRT(Veiculo veiculoInfo)
        {
            InitializeComponent();
            veiculo = veiculoInfo;
            copiaVeiculo = veiculoInfo;
            this.Text = $"{veiculo.Placa} - {veiculo.FIPEModelo}";
        }

        #endregion

        private void frmVeiculoPRT_Load(object sender, EventArgs e)
        {
            dataAtual = DateTime.Now;
            dataInicialAtual = new DateTime(dataAtual.Year, dataAtual.Month, 1);
            dataFinalAtual = new DateTime(dataAtual.Year, dataAtual.Month, DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month));
            dataInicialdoAno = new DateTime(dataAtual.Year, 01, 01); //janeiro do ano corrente
            dataFinaldoAno = new DateTime(dataAtual.Year, 12, 31); // dezembro do ano corrente

            dateTimePickerFiltroDashDataInicial.Value = dataInicialdoAno;
            dateTimePickerFiltroDashDataFinal.Value = dataAtual;

            label12.Text = $"Registros do ano {dataAtual.Year}";
            label13.Text = $"Registros do ano {dataAtual.Year}";
            label30.Text = $"Dados parciais de {dataInicialdoAno.ToShortDateString()} à {dataAtual.ToShortDateString()}";
            groupBox35.Text = "Consumo médio dos últimos 3 meses";
            lblDataAtual.Text = dataAtual.ToShortDateString();           
            btnSalvarAlteracoesSeguro.Visible = false;
            rdAmbas.Checked = true;
            cmbFiltroDataMultaPor.SelectedIndex = 0;
            btnSalvar.BackColor = Color.Gainsboro;
            btnCancelar.Visible = false;           
            chkPagamentoRealizado.Checked = false;
            dateTimePickerDataPagamentoDocumento.Visible = false;
            labelDataPagamentoDocumento.Visible = false;
            dateTimePickerDataPagamentoDocumento2.Visible = false;
            labelDataPagamentoDocumento2.Visible = false;
            btnInformarPagamentoDocumento.Visible = false;
            btnCancelarInformarPagamentoDocumento.Visible = false;

            CarregarGrids();
            CarregarComboBox();   
            PreencherFormularioDocumento();
            DesabilitarCampos();
            CarregarContratoSeguro();
                                   
            if (String.IsNullOrEmpty(txtAnexarDocumento.Text) || String.IsNullOrWhiteSpace(txtAnexarDocumento.Text))
                btnVisualizarDocumento.Visible = false;
            else
                btnVisualizarDocumento.Visible = true;
            
            CarregarDashboard();

            //Aba manutenção
            label100.Text = String.Empty;
            label101.Text = String.Empty;
            label102.Text = String.Empty;
            label103.Text = String.Empty;
            linkLabel1.Text = String.Empty;
            label111.Text = String.Empty;
        }

        public void CarregarGrids()
        {
            CarregaDatagridAoAbrir(dataInicialAtual, dataFinalAtual, veiculo);
            CarregarDatagridManutencao(veiculo);            
            CarregarDatagridMulta(veiculo);
            CarregarGridPagamentoDocumento(dataAtual, veiculo);
        }

        public void CarregarComboBox()
        {
            PreencherComboBoxCombustivel();
            PreencherComboBoxAbastecimento();
            PreencherComboBoxAbastecimentoFiltro();          
            PreencherComboBoxMecanica();
            PreencherComboBoxLocalManutencao();
            CarregarComboBoxFiltroSeguradora();
        }

        #region Aba DashBoard

        private void btnAplicarFiltroDashboard_Click(object sender, EventArgs e)
        {
            label30.Text = $"Dados parciais de {dateTimePickerFiltroDashDataInicial.Value.ToShortDateString()} à {dateTimePickerFiltroDashDataFinal.Value.ToShortDateString()}";
            CarregarDashboardPorFiltro(dateTimePickerFiltroDashDataInicial.Value, dateTimePickerFiltroDashDataFinal.Value);            
        }

        public void CarregarDashboard()
        {
            graficoPizzaAnual.Total = 0;
            CarregarDashBoardConsumoCombustivelKm(false, DateTime.Now, DateTime.Now, dataAtual.Date, veiculo);          
            CarregarDashBoardGastoManutencaoAnual(false, DateTime.Now, DateTime.Now, dataAtual.Date, veiculo);
            CarregarDashBoardGastoManutencaoTotal(veiculo);
            CarregarDashBoardTotalMulta(false, DateTime.Now, DateTime.Now, dataAtual.Date, veiculo);
            CarregarDashBoardTotalSeguro(false, DateTime.Now, DateTime.Now, dataAtual.Date, veiculo);
            CarregarDashBoardTotalPagamentoDocumento(false, DateTime.Now, DateTime.Now, dataAtual.Date, veiculo);
            CarregarDashBoardConsumo(false, DateTime.Now, DateTime.Now, dataAtual.Date, veiculo);
            PlotGraficoPizzaAnual();
        }

        public void CarregarDashboardPorFiltro(DateTime dtInicial, DateTime dtFinal)
        {
            graficoPizzaAnual.Total = 0;
            CarregarDashBoardConsumoCombustivelKm(true, dtInicial, dtFinal, dataAtual.Date, veiculo);            
            CarregarDashBoardGastoManutencaoAnual(true, dtInicial, dtFinal, dataAtual.Date, veiculo);
            CarregarDashBoardGastoManutencaoTotal(veiculo);
            CarregarDashBoardTotalMulta(true, dtInicial, dtFinal, dataAtual.Date, veiculo);
            CarregarDashBoardTotalSeguro(true, dtInicial, dtFinal, dataAtual.Date, veiculo);
            CarregarDashBoardTotalPagamentoDocumento(true, dtInicial, dtFinal, dataAtual.Date, veiculo);
            CarregarDashBoardConsumo(false, dtInicial, dtFinal, dataAtual.Date, veiculo);
            PlotGraficoPizzaAnual();
        }

        private void CarregarDashBoardConsumoCombustivelKm(bool filter, DateTime dataInicial, DateTime dataFinal, DateTime dataAtual, Veiculo veiculo)
        {
            ConsumoInfo consumo;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
                        
            CustoDiario quantidadeDiasRegistro;

            if (filter)
            {
                consumo = abastecimentoBLL.GetConsumo(dataInicial, dataFinal, veiculo);
                quantidadeDiasRegistro = abastecimentoBLL.GetDiasRegistro(dataInicial, dataFinal, veiculo);
            }
            else
            {
                consumo = abastecimentoBLL.GetConsumoAnual(dataAtual.Date, veiculo);
                quantidadeDiasRegistro = abastecimentoBLL.GetDiasRegistroParcialAnual(dataAtual, veiculo);
            }

            #region Preenchimento do custo do consumo
                   
            decimal custoDiario = 0;

            label65.Text = $"Consumido até o momento em {dataAtual.Year}";

            if (consumo.ValorAlcool != 0)
            {
                listBox1.Items.Add("Alcool:");
                listBox2.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", consumo.ValorAlcool));
                listBox4.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0} lts", consumo.QuantidadeAlcool));
                custoDiario = consumo.ValorAlcool / quantidadeDiasRegistro.DiasAlcool;
                listBox5.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", custoDiario));
                listBox6.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", (consumo.ValorAlcool / consumo.KM)));
            }
            if (consumo.ValorDiesel != 0)
            {
                listBox1.Items.Add("Diesel:");
                listBox2.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", consumo.ValorDiesel));
                listBox4.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0} lts", consumo.QuantidadeDiesel));
                custoDiario = consumo.ValorDiesel / quantidadeDiasRegistro.DiasDiesel;
                listBox5.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", custoDiario));
                listBox6.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", (consumo.ValorDiesel / consumo.KM)));
            }
            if (consumo.ValorGasolina != 0)
            {
                listBox1.Items.Add("Gasolina:");
                listBox2.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", consumo.ValorGasolina));
                listBox4.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0} lts", consumo.QuantidadeGasolina));
                custoDiario = consumo.ValorGasolina / quantidadeDiasRegistro.DiasGasolina;
                listBox5.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", custoDiario));
                listBox6.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", (consumo.ValorGasolina / consumo.KM)));
            }
            if (consumo.ValorGNV != 0)
            {
                listBox1.Items.Add("GNV:");
                listBox2.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", consumo.ValorGNV));
                listBox4.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0} m³ ", consumo.QuantidadeGNV));
                custoDiario = consumo.ValorGNV / quantidadeDiasRegistro.DiasGNV;
                listBox5.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", custoDiario));
                listBox6.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", (consumo.ValorGNV / consumo.KM)));
            }

            #endregion

            #region Preenchimento Distancia           

            lblKmAnual.Text = string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:N0} Km", consumo.KM);
            lblMediaDiaria.Text = string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:N0} Km", (consumo.KM / quantidadeDiasRegistro.TotalDiasRegistro));

            #endregion

            graficoPizzaAnual.TotalCombustivel = consumo.ValorAlcool + consumo.ValorDiesel + consumo.ValorGasolina + consumo.ValorGNV;
            graficoPizzaAnual.Total += graficoPizzaAnual.TotalCombustivel;
        }
                                
        private void CarregarDashBoardGastoManutencaoAnual(bool filter, DateTime dataInicial, DateTime dataFinal, DateTime dataAtual, Veiculo veiculo)
        {
            GastoManutencaoInfo gasto;

            if (filter)
                gasto = manutencaoBLL.GetGasto(dataInicial, dataFinal, veiculo);
            else
                gasto = manutencaoBLL.GetGastoAnual(dataAtual, veiculo);

            label76.Text = $"Valor de manutenção";
            label77.Text = string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", gasto.TotalValor);

            graficoPizzaAnual.TotalManutencao = gasto.TotalValor;
            graficoPizzaAnual.Total += graficoPizzaAnual.TotalManutencao;
        }

        private void CarregarDashBoardGastoManutencaoTotal(Veiculo veiculo)
        {
            GastoManutencaoInfo gasto = manutencaoBLL.GetGasto(veiculo);

            label15.Text = string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", gasto.TotalValor);
            label80.Text = $"Total de manutenções no veículo";
            label81.Text = string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", gasto.TotalValor);
        }

        private void CarregarDashBoardTotalMulta(bool filter, DateTime dataInicial, DateTime dataFinal, DateTime dataAtual, Veiculo veiculo)
        {
            if (filter)
                graficoPizzaAnual.TotalMulta = multaBLL.GetMultaPorPeriodo(dataInicial, dataFinal, veiculo);
            else
                graficoPizzaAnual.TotalMulta = multaBLL.GetMultaTotalAnual(dataAtual, veiculo);

            label83.Text = $"Valor de multas";
            label84.Text = string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", graficoPizzaAnual.TotalMulta);
            graficoPizzaAnual.Total += graficoPizzaAnual.TotalMulta;
           
        }

        private void CarregarDashBoardTotalSeguro(bool filter, DateTime dataInicial, DateTime dataFinal, DateTime dataAtual, Veiculo veiculo)
        {
            if (filter)
                graficoPizzaAnual.TotalSeguro = contratoSeguradoraBLL.GetPagamentoSeguroAnual(dataInicial, veiculo);
            else
                graficoPizzaAnual.TotalSeguro = contratoSeguradoraBLL.GetPagamentoSeguroAnual(dataAtual, veiculo);

            label85.Text = $"Valor de seguro";
            label86.Text = string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", graficoPizzaAnual.TotalSeguro);
            graficoPizzaAnual.Total += graficoPizzaAnual.TotalSeguro;
        }

        private void CarregarDashBoardTotalPagamentoDocumento(bool filter, DateTime dataInicial, DateTime dataFinal, DateTime dataAtual, Veiculo veiculo)
        {
            if (filter)
                graficoPizzaAnual.TotalDocumento = pagamentoDocumentoBLL.GetoPagamentoDocumentoTotalAnual(dataInicial, veiculo);
            else
                graficoPizzaAnual.TotalDocumento = pagamentoDocumentoBLL.GetoPagamentoDocumentoTotalAnual(dataAtual, veiculo);

            label94.Text = $"Valor de documento";
            label95.Text = string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", graficoPizzaAnual.TotalDocumento);
            graficoPizzaAnual.Total += graficoPizzaAnual.TotalDocumento;
        }

        private void CarregarDashBoardConsumo(bool filter, DateTime dataInicial, DateTime dataFinal, DateTime dataAtual, Veiculo veiculo)
        {
            dataGridView1.Rows.Clear();
            List<AutonomiaInfo> listMedia;

            if (filter)
                listMedia = abastecimentoBLL.GetAutonomia(dataAtual, veiculo);
            else
                listMedia = abastecimentoBLL.GetAutonomia(dataAtual, veiculo);

            //header
            if (listMedia.Count > 0)
            {
                dataGridView1.ColumnCount = listMedia.Count;

                dataGridView1.Columns[0].Name = "Mês";
                dataGridView1.Columns[0].Width = 70;

                var headerAlcool = false;
                var headerGasolina = false;
                var headerGNV = false;
                var headerDiesel = false;

                for (int i = 1; i < listMedia.Count; i++)
                {
                    if (!string.IsNullOrEmpty(listMedia[0].MediaAlcool) && !string.IsNullOrWhiteSpace(listMedia[0].MediaAlcool) && !headerAlcool)
                    {
                        dataGridView1.Columns[i].Name = "Alcool";
                        dataGridView1.Columns[i].Width = 70;
                        headerAlcool = true;
                        continue;
                    }
                    if (!string.IsNullOrEmpty(listMedia[0].MediaGasolina) && !string.IsNullOrWhiteSpace(listMedia[0].MediaGasolina) && !headerGasolina)
                    {
                        dataGridView1.Columns[i].Name = "Gasolina";
                        dataGridView1.Columns[i].Width = 70;
                        headerGasolina = true;
                        continue;
                    }
                    if (!string.IsNullOrEmpty(listMedia[0].MediaGNV) && !string.IsNullOrWhiteSpace(listMedia[0].MediaGNV) && !headerGNV)
                    {
                        dataGridView1.Columns[i].Name = "GNV";
                        dataGridView1.Columns[i].Width = 80;
                        headerGNV = true;
                        continue;
                    }
                    if (!string.IsNullOrEmpty(listMedia[0].MediaDiesel) && !string.IsNullOrWhiteSpace(listMedia[0].MediaDiesel) && !headerDiesel)
                    {
                        dataGridView1.Columns[i].Name = "Diesel";
                        dataGridView1.Columns[i].Width = 70;
                        headerDiesel = true;
                        continue;
                    }
                }
            }            

            //Cells
            foreach (var item in listMedia)
            {     
                List<string> row = new List<string>();

                row.Add(item.Mes);

                if (!string.IsNullOrEmpty(item.MediaAlcool) && !string.IsNullOrWhiteSpace(item.MediaAlcool))
                    row.Add(item.MediaAlcool);
                if (!string.IsNullOrEmpty(item.MediaGasolina) && !string.IsNullOrWhiteSpace(item.MediaGasolina))
                    row.Add(item.MediaGasolina);
                if (!string.IsNullOrEmpty(item.MediaGNV) && !string.IsNullOrWhiteSpace(item.MediaGNV))
                    row.Add(item.MediaGNV);
                if (!string.IsNullOrEmpty(item.MediaDiesel) && !string.IsNullOrWhiteSpace(item.MediaDiesel))
                    row.Add(item.MediaDiesel);
                                
                dataGridView1.Rows.Add(row.ToArray());
            }         
        }

        private void PlotGraficoPizzaAnual()
        {
            this.chart1.Series[0].Points.Clear();

            //referencia
            // https://betterdashboards.wordpress.com/2009/02/04/display-percentages-on-a-pie-chart/
            //https://stackoverflow.com/questions/10622674/chart-creating-dynamically-in-net-c-sharp
            //https://stackoverflow.com/questions/8403866/values-in-a-pie-chart

            if (graficoPizzaAnual.Total > 0)
            {
                //  var total = graficoPizzaAnual.TotalCombustivel + graficoPizzaAnual.TotalManutencao + graficoPizzaAnual.TotalOleo;
                label82.Text = $"Gasto até o momento: {string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:C}", graficoPizzaAnual.Total)}";

                //calculo do percentual combustivel
                double percentualCombustivel = Convert.ToDouble((graficoPizzaAnual.TotalCombustivel * 100) / graficoPizzaAnual.Total);
                //calculo do percentual Manutenção
                double percentualManutencao = Convert.ToDouble((graficoPizzaAnual.TotalManutencao * 100) / graficoPizzaAnual.Total);                
                //calculo do percentual multa
                double percentualMulta = Convert.ToDouble((graficoPizzaAnual.TotalMulta * 100) / graficoPizzaAnual.Total);
                //calculo do percentual seguro
                double percentualSeguro = Convert.ToDouble((graficoPizzaAnual.TotalSeguro * 100) / graficoPizzaAnual.Total);
                //calculo do percentual Documento
                double percentualDocumento = Convert.ToDouble((graficoPizzaAnual.TotalDocumento * 100) / graficoPizzaAnual.Total);

                //define o tipo de grafico
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                //define a localização da legenda no grafico
                //chart1.Series[0]["PieLabelStyle"] = "Disabled";
                chart1.Series[0]["PieLabelStyle"] = "Outside";
                //define os pontos do grafico
                this.chart1.Series[0].Points.AddXY(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "Combustivel - {0:C}", graficoPizzaAnual.TotalCombustivel), percentualCombustivel);
                this.chart1.Series[0].Points.AddXY(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "Manutenção - {0:C}", graficoPizzaAnual.TotalManutencao), percentualManutencao);               
                this.chart1.Series[0].Points.AddXY(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "Multa - {0:C}", graficoPizzaAnual.TotalMulta), percentualMulta);
                this.chart1.Series[0].Points.AddXY(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "Seguro - {0:C}", graficoPizzaAnual.TotalSeguro), percentualSeguro);
                this.chart1.Series[0].Points.AddXY(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "Documento - {0:C}", graficoPizzaAnual.TotalDocumento), percentualDocumento);

                //define as cores dos pontos do grafico
                this.chart1.Series[0].Points[0].Color = Color.Yellow;
                this.chart1.Series[0].Points[1].Color = Color.Tomato;               
                this.chart1.Series[0].Points[2].Color = Color.LightSkyBlue;
                this.chart1.Series[0].Points[3].Color = Color.DarkViolet;
                this.chart1.Series[0].Points[4].Color = Color.Coral;

                // By sorting the data points, they show up in proper ascending order in the legend
                this.chart1.DataManipulator.Sort(PointSortOrder.Descending, chart1.Series[0]);
                //cria borda
                this.chart1.Series[0].BorderWidth = 1;
                this.chart1.Series[0].BorderColor = System.Drawing.Color.FromArgb(26, 59, 105);


                // Add a legend to the chart and dock it to the bottom-center
                // this.chart1.Legends.Add("Legend1");
                this.chart1.Legends[0].Enabled = true;
                this.chart1.Legends[0].Docking = Docking.Bottom;
                this.chart1.Legends[0].Alignment = System.Drawing.StringAlignment.Center;

                // Set the legend to display pie chart values as percentages
                // Again, the P2 indicates a precision of 2 decimals
                this.chart1.Series[0].LegendText = "#VALX";
                // Set the pie label as well as legend text to be displayed as percentage
                // The P2 indicates a precision of 2 decimals
                this.chart1.Series[0].Label = "#PERCENT{P2}";

                // By sorting the data points, they show up in proper ascending order in the legend
                this.chart1.DataManipulator.Sort(PointSortOrder.Descending, chart1.Series[0]);
            }           
        }
             
        #endregion

        #region Aba Abastecimento

        private void btnInserirAbastecimento_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtPathComprovanteAbastecimento.Text) || !String.IsNullOrWhiteSpace(txtPathComprovanteAbastecimento.Text))
                {
                    VerificaPasta(pathComprovante);
                    CopiaComprovante(pathOrigemComprovante, pathDestinoComprovante);
                }

                Abastecimento info = new Abastecimento
                {
                    Data = dateTimePickerAbastecimento.Value.Date,
                    KM = Convert.ToInt64(txtKMAbastecimento.Text),
                    Veiculo = veiculo,
                    CombustivelId = combustivelBLL.GetIdCombustivel(cmbCombustivelAbastecimento.Text),
                    Valor = Convert.ToDecimal(txtValorAbastecimento.Text),
                    Quantidade = Convert.ToDecimal(txtQuantidadeAbastecimento.Text),
                    PathComprovantePDF = fileNameComprovante
                };

                abastecimentoBLL.Insert(info);

                cmbCombustivelAbastecimento.SelectedIndex = -1;
                txtKMAbastecimento.Clear();
                txtValorAbastecimento.Clear();
                txtQuantidadeAbastecimento.Clear();
                txtPathComprovanteAbastecimento.Clear();
                CarregaDatagridAoAbrir(dataInicialAtual, dataFinalAtual, veiculo);                
                CarregarDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao lançar abastecimento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAplicarFiltroAbastecimentos_Click(object sender, EventArgs e)
        {
            dtAbastecimento.DataSource = abastecimentoBLL.ListPorFiltro(dateTimePickerFiltroDataInicial.Value.Date,
                dateTimePickerFilroDataFinal.Value.Date, veiculo,
                combustivelBLL.GetIdCombustivel(cmbCombustivelAbastecimentoFiltro.Text));

            FormartaDataGridViewAbastecimentos();
            CarregarDashBoardLocalConsumoCombustivelKmPercorridoParcial(dateTimePickerFiltroDataInicial.Value.Date, dateTimePickerFilroDataFinal.Value.Date, veiculo);
            label12.Text = $"Registros de {dateTimePickerFiltroDataInicial.Value.ToShortDateString()} à {dateTimePickerFilroDataFinal.Value.ToShortDateString()}";
        }

        private void btnRemoverFiltroCombustivel_Click(object sender, EventArgs e)
        {
            cmbCombustivelAbastecimentoFiltro.SelectedIndex = -1;
        }

        private void btnAnexarComprovante_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new OpenFileDialog();

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathOrigemComprovante = this.openFileDialog1.FileName;
                fileNameComprovante = this.openFileDialog1.SafeFileName;
                pathDestinoComprovante = Path.Combine(pathComprovante, fileNameComprovante);
                txtPathComprovanteAbastecimento.Text = pathOrigemComprovante;
            }
        }

        private void btnVisualizarComprovanteAbastecimento_Click(object sender, EventArgs e)
        {
            string fileNameCompro = (string)dtAbastecimento.CurrentRow.Cells[7].Value;
            if (String.IsNullOrEmpty(fileNameCompro) || String.IsNullOrWhiteSpace(fileNameCompro))
                MessageBox.Show("Este registro não possui comprovante anexado.", "Sem comprovante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                try
                {
                    pathDestinoComprovante = Path.Combine(pathComprovante, fileNameCompro);
                    Process.Start(pathDestinoComprovante);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Falha ao localizar comprovante. {ex.Message}", "Sem comprovante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnAdicionarComprovante_Click(object sender, EventArgs e)
        {
            string fileNameCompro = (string)dtAbastecimento.CurrentRow.Cells[7].Value;
            if (String.IsNullOrEmpty(fileNameCompro) || String.IsNullOrWhiteSpace(fileNameCompro))
            {
                int id = (int)dtAbastecimento.CurrentRow.Cells[0].Value;
                frmAdicionarComprovante frm = new frmAdicionarComprovante(id, TipoAnexo.Abastecimento);
                frm.ShowDialog();
                CarregaDatagridAoAbrir(dataInicialAtual.Date, dataFinalAtual.Date, veiculo);
            }
            else
            {
                if (MessageBox.Show("Este registro já possui comprovante anexado, deseja alterar?", "Comprovante já anexado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int id = (int)dtAbastecimento.CurrentRow.Cells[0].Value;
                    frmAdicionarComprovante frm = new frmAdicionarComprovante(id, TipoAnexo.Abastecimento);
                    frm.ShowDialog();
                    CarregaDatagridAoAbrir(dataInicialAtual.Date, dataFinalAtual.Date, veiculo);
                }
            }
        }

        private void PreencherComboBoxAbastecimento()
        {
            var combusitiveis = combustivelBLL.GetList(veiculo);

            //preenche o combo combustivel Abastecimento
            cmbCombustivelAbastecimento.DataSource = combusitiveis;
            cmbCombustivelAbastecimento.DisplayMember = "Tipo";
            cmbCombustivelAbastecimento.ValueMember = "Id";
            cmbCombustivelAbastecimento.SelectedIndex = -1;
        }

        private void PreencherComboBoxAbastecimentoFiltro()
        {
            var combusitiveis = combustivelBLL.GetList(veiculo);

            //preenche o combo combustivel Abastecimento filtro
            cmbCombustivelAbastecimentoFiltro.DataSource = combusitiveis;
            cmbCombustivelAbastecimentoFiltro.DisplayMember = "Tipo";
            cmbCombustivelAbastecimentoFiltro.ValueMember = "Id";
            cmbCombustivelAbastecimentoFiltro.SelectedIndex = -1;
        }

        private void CarregarDashBoardLocalConsumoCombustivelKmPercorridoParcial(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            listBox3.Items.Clear();
            ConsumoInfo consumo = abastecimentoBLL.GetConsumo(dtInicial.Date, dtFinal.Date, veiculo);          

            label66.Text = $"Gasto até o momento em {dataAtual.Year}";

            if (consumo.ValorAlcool != 0)
                listBox3.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "Alcool:   {0:C}    {1} lts", consumo.ValorAlcool, consumo.QuantidadeAlcool));
            if (consumo.ValorDiesel != 0)
                listBox3.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "Diesel:   {0:C}    {1} lts", consumo.ValorDiesel, consumo.QuantidadeDiesel));
            if (consumo.ValorGasolina != 0)
                listBox3.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "Gasolina: {0:C}    {1} lts", consumo.ValorGasolina, consumo.QuantidadeGasolina));
            if (consumo.ValorGNV != 0)
                listBox3.Items.Add(string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "GNV :       {0:C}    {1} m³ ", consumo.ValorGNV, consumo.QuantidadeGNV));

            //Atualiza o dashboard de KM percorrido parcial
            label68.Text = $"Percorrido até o momento em {dataAtual.Year}";
            label69.Text = string.Format(CultureInfo.GetCultureInfo(veiculo.CultureInfo), "{0:N0} Km", consumo.KM);
        }
               
        private void CarregaDatagridAoAbrir(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            dtAbastecimento.DataSource = abastecimentoBLL.ListParcialAnual(DateTime.Now.Date, veiculo);

            CarregarDashBoardLocalConsumoCombustivelKmPercorridoParcial(dataInicialdoAno, dataFinaldoAno, veiculo);        
            FormartaDataGridViewAbastecimentos();
        }

        private void FormartaDataGridViewAbastecimentos()
        {
            ////esconde as colunas desnecessárias            
            dtAbastecimento.Columns["Data"].Visible = false;

            //ajusta lagura da coluna
            dtAbastecimento.Columns["Id"].Width = 50;
            dtAbastecimento.Columns["DataS"].Width = 80;
            dtAbastecimento.Columns["KM"].Width = 70;
            dtAbastecimento.Columns["Combustivel"].Width = 127;
            dtAbastecimento.Columns["Quantidade"].Width = 100;
            dtAbastecimento.Columns["Valor"].Width = 80;
            dtAbastecimento.Columns["PathComprovantePDF"].Width = 200;

            //ajusta o texto header do grid
            dtAbastecimento.Columns["Quantidade"].HeaderText = "Qntd. (lts/m³)";
            dtAbastecimento.Columns["PathComprovantePDF"].HeaderText = "Comprovante";
            dtAbastecimento.Columns["DataS"].HeaderText = "Data";
        }

        #endregion

       
        #region Aba Manunteção

        private void btnCadastrarMecanica_Click(object sender, EventArgs e)
        {
            using (frmCadastarMecanica frmMecanicas = new frmCadastarMecanica())
            {
                frmMecanicas.ShowDialog();
            }

            PreencherComboBoxMecanica();
        }

        private void btnVisualizarMecanicas_Click(object sender, EventArgs e)
        {
            using (frmMecanicas frmMecanica = new frmMecanicas())
            {
                frmMecanica.ShowDialog();
            }
        }

        private void PreencherComboBoxMecanica()
        {
            try
            {
                var mecanicas = mecanicaBLL.List();

                //preenche o combo combustivel Abastecimento filtro
                cmbMecanica.DataSource = mecanicas;
                cmbMecanica.DisplayMember = "Nome";
                cmbMecanica.ValueMember = "Id";
                cmbMecanica.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problemas ao recuperar os dados: {ex.Message}", "Falha de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherComboBoxLocalManutencao()
        {
            try
            {
                var tipos = manutencaoBLL.ListTipoManutencao();

                //preenche o combo combustivel Abastecimento filtro
                cmbTipoManutencao.DataSource = tipos;
                cmbTipoManutencao.DisplayMember = "Descricao";
                cmbTipoManutencao.ValueMember = "Id";
                cmbTipoManutencao.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problemas ao recuperar os dados: {ex.Message}", "Falha de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLancarManutencao_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtPathComprovanteManutencao.Text) || !String.IsNullOrWhiteSpace(txtPathComprovanteManutencao.Text))
                {
                    VerificaPasta(pathComprovante);
                    CopiaComprovante(pathOrigemComprovante, pathDestinoComprovante);
                }

                Manutencao manu = new Manutencao
                {
                    Data = dateTimePickerManutencao.Value.Date,
                    Valor = Convert.ToDecimal(txtValorManutencao.Text),
                    Descricao = txtDescricaoManutencao.Text,
                    MecanicaID = (cmbMecanica.SelectedValue == null) ? -1 : (int)cmbMecanica.SelectedValue,
                    TipoManutencaoID = (cmbTipoManutencao.SelectedValue == null) ? -1 : (int)cmbTipoManutencao.SelectedValue,
                    Veiculo = veiculo,
                    KM = Convert.ToInt64(txtKMManutencao.Text),
                    PathComprovantePDF = fileNameComprovante
                };

                manutencaoBLL.Insert(manu);

                txtValorManutencao.Clear();
                txtDescricaoManutencao.Clear();
                txtPathComprovanteManutencao.Clear();
                txtKMManutencao.Clear();
                cmbMecanica.SelectedIndex = -1;
                dateTimePickerManutencao.Value = DateTime.Now;
                CarregarDatagridManutencao(veiculo);
                CarregarDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir manutenção: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void btnAplicarFiltroMecanica_Click(object sender, EventArgs e)
        {
            CarregarDatagridManutencao(dateTimePickerDataIncialMecanicaFiltro.Value.Date, dateTimePickerDataFinalMecanicaFiltro.Value.Date, veiculo);
        }

        private void btnAnexarComprovanteManutencao_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new OpenFileDialog();

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathOrigemComprovante = this.openFileDialog1.FileName;
                fileNameComprovante = this.openFileDialog1.SafeFileName;
                pathDestinoComprovante = Path.Combine(pathComprovante, fileNameComprovante);
                txtPathComprovanteManutencao.Text = fileNameComprovante;
            }
        }

        //private void btnVisualizarComprovanteManutencao_Click(object sender, EventArgs e)
        //{
        //    int id = (int)dtManutencao.CurrentRow.Cells[0].Value;
        //    Manutencao manutencao = new ManutencaoBLL().Get(id);
        //    if (String.IsNullOrEmpty(manutencao.PathComprovantePDF) || String.IsNullOrWhiteSpace(manutencao.PathComprovantePDF))
        //        MessageBox.Show("Este registro não possui comprovante anexado.", "Sem comprovante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    else
        //    {
        //        try
        //        {
        //            pathDestinoComprovante = Path.Combine(pathComprovante, manutencao.PathComprovantePDF);
        //            Process.Start(pathDestinoComprovante);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Falha ao localizar comprovante. {ex.Message}", "Sem comprovante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        }
        //    }
        //}

        private void btnAnexaComprovanteManutencaoDepois_Click(object sender, EventArgs e)
        {
            if (manutencaoVisualizacao != null)
            {
                //string fileNameCompro = (string)dtManutencao.CurrentRow.Cells[6].Value;
                if (String.IsNullOrEmpty(manutencaoVisualizacao.PathComprovantePDF) || String.IsNullOrWhiteSpace(manutencaoVisualizacao.PathComprovantePDF))
                {
                    int id = (int)dtManutencao.CurrentRow.Cells[0].Value;
                    frmAdicionarComprovante frm = new frmAdicionarComprovante(id, TipoAnexo.Manutencao);
                    frm.ShowDialog();
                    CarregarDatagridManutencao(veiculo);
                }
                else
                {
                    MessageBox.Show("Este registro já possui comprovante anexado.", "Comprovante já anexado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Selecione um registro de manutenção para poder ser adicionado um comprovante!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           
            
        }

        private void CarregarDatagridManutencao(Veiculo veiculo)
        {
            dtManutencao.DataSource = manutencaoBLL.ListParcialAnual(DateTime.Now.Date, veiculo);

            FormartaDataGridViewManutencao();
        }

        private void CarregarDatagridManutencao(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            dtManutencao.DataSource = manutencaoBLL.List(dtInicial.Date, dtFinal.Date, veiculo);

            FormartaDataGridViewManutencao();
            CarregarGastoManutencaoParcial(dtInicial.Date, dtFinal.Date, veiculo);
        }

        private void CarregarGastoManutencaoParcial(DateTime dataIniAtual, DateTime dataFinAtual, Veiculo veiculo)
        {
            GastoManutencaoInfo gasto = manutencaoBLL.GetGasto(dataIniAtual.Date, dataFinAtual.Date, veiculo);

            label80.Text = $"Total de manutenções de {dataIniAtual.ToShortDateString()} à {dataFinAtual.ToShortDateString()}";
            label81.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", gasto.TotalValor);
        }

        private void FormartaDataGridViewManutencao()
        {
            //esconde as colunas desnecessárias
            dtManutencao.Columns["Data"].Visible = false;

            //ajusta lagura da coluna
            dtManutencao.Columns["Id"].Width = 50;
            dtManutencao.Columns["DataS"].Width = 80;
            dtManutencao.Columns["KM"].Width = 60;
            dtManutencao.Columns["Descricao"].Width = 277;
            dtManutencao.Columns["Valor"].Width = 80;
            dtManutencao.Columns["PathComprovantePDF"].Width = 95;

            //alinhamento dos headers das colunas
            foreach (DataGridViewColumn col in dtManutencao.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }


            //alinhamento das colunas
            dtManutencao.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtManutencao.Columns["DataS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtManutencao.Columns["KM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtManutencao.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtManutencao.Columns["PathComprovantePDF"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //ajusta o texto header do grid
            dtManutencao.Columns["PathComprovantePDF"].HeaderText = "Comprovante";
            dtManutencao.Columns["Descricao"].HeaderText = "Realizado"; 
            dtManutencao.Columns["DataS"].HeaderText = "Data";
        }

        private void btnTipoManutencao_Click(object sender, EventArgs e)
        {
            frmTipoManutencao frm = new frmTipoManutencao();
            frm.ShowDialog();
            PreencherComboBoxLocalManutencao();
        }

        private void dtManutencao_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            manutencaoVisualizacao = null;
            int id = (int)dtManutencao.CurrentRow.Cells[0].Value;
            manutencaoVisualizacao = manutencaoBLL.Get(id);

            if (manutencaoVisualizacao != null)
            {
                label100.Text = manutencaoVisualizacao.DataS;
                label101.Text = (manutencaoVisualizacao.Mecanica == null) ? "" : manutencaoVisualizacao.Mecanica.Nome;
                label102.Text = manutencaoVisualizacao.KM.ToString();
                label103.Text = manutencaoVisualizacao.Valor.ToString();
                linkLabel1.Text = (String.IsNullOrEmpty(manutencaoVisualizacao.PathComprovantePDF) || String.IsNullOrWhiteSpace(manutencaoVisualizacao.PathComprovantePDF)) ? "" : manutencaoVisualizacao.PathComprovantePDF;
                textBox1.Text = manutencaoVisualizacao.Descricao;
                label111.Text = manutencaoVisualizacao.TipoManutencao;

                if (String.IsNullOrEmpty(manutencaoVisualizacao.PathComprovantePDF) && String.IsNullOrWhiteSpace(manutencaoVisualizacao.PathComprovantePDF))
                {
                    btnAnexaComprovanteManutencaoDepois.Enabled = true;
                }
                else
                    btnAnexaComprovanteManutencaoDepois.Enabled = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pathDestinoComprovante = Path.Combine(pathComprovante, linkLabel1.Text);
            Process.Start(pathDestinoComprovante);
        }

        #endregion

        #region Aba Documento

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Salvar();
                DesabilitarCampos();
                btnSalvar.Visible = false;
                btnSalvar.BackColor = Color.Gainsboro;
                btnEditar.Enabled = true;
                btnEditar.BackColor = Color.LightSalmon;
                btnCancelar.Visible = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarCampos();

            btnSalvar.Visible = true;
            btnSalvar.BackColor = Color.MediumAquamarine;
            btnEditar.Enabled = false;
            btnEditar.BackColor = Color.Gainsboro;
            btnCancelar.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DesabilitarCampos();
            btnSalvar.Visible = false;
            btnSalvar.BackColor = Color.Gainsboro;
            btnEditar.Enabled = true;
            btnEditar.BackColor = Color.LightSalmon;
            btnCancelar.Visible = false;
            lblMensagem.Visible = false;
            //esconde mensagem de erro, se estiver ativo
            lblMensagem.Visible = false;
                  
            veiculo = copiaVeiculo;
            PreencherFormularioDocumento();
        }

        private void btnAlterarVeiculo_Click(object sender, EventArgs e)
        {
            using (frmAlterarVeiculo frmAlterarCarro = new frmAlterarVeiculo(veiculo))
            {
                frmAlterarCarro.ShowDialog();

                if (frmAlterarCarro.Veiculo != null)
                {
                    veiculo = frmAlterarCarro.Veiculo;

                    PreencherFormularioDocumento();                   
                }
            }
        }
              
        private void btnAnexarDocumento_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new OpenFileDialog();

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathOrigemComprovante = this.openFileDialog1.FileName;
                fileNameComprovante = this.openFileDialog1.SafeFileName;
                pathDestinoComprovante = Path.Combine(pathDocumentos, fileNameComprovante);
                txtAnexarDocumento.Text = fileNameComprovante;
            }
        }

        private void btnVisualizarDocumento_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAnexarDocumento.Text) || String.IsNullOrWhiteSpace(txtAnexarDocumento.Text))
                MessageBox.Show("Este registro não possui documento anexado.", "Sem comprovante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                try
                {
                    pathDestinoComprovante = Path.Combine(pathDocumentos, txtAnexarDocumento.Text);
                    Process.Start(pathDestinoComprovante);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Falha ao localizar documento. {ex.Message}", "Sem documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnLancarPagamentoDocumento_Click(object sender, EventArgs e)
        {
            try
            {               
                PagamentoDocumento info = new PagamentoDocumento
                {
                    DataVencimento = dateTimePickerDataVencimentoDocumento.Value.Date,                                      
                    Veiculo = veiculo,                    
                    Valor = Convert.ToDecimal(txtValorPagamentoDocumento.Text),
                    Descricao = txtDecricaoPagamentoDocumento.Text
                };

                if (chkPagamentoRealizado.Checked)
                    info.DataPagamento = dateTimePickerDataPagamentoDocumento.Value.Date;
                else
                    info.DataPagamento = new DateTime(2000, 01, 01);

                pagamentoDocumentoBLL.Insert(info);

                txtValorPagamentoDocumento.Clear();
                txtDecricaoPagamentoDocumento.Clear();
                dateTimePickerDataPagamentoDocumento.Value = DateTime.Now;
                CarregarGridPagamentoDocumento(dataAtual, veiculo);
                CarregarDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao lançar pagamento do documento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkPagamentoRealizado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPagamentoRealizado.Checked)
            {
                labelDataPagamentoDocumento.Visible = true;
                dateTimePickerDataPagamentoDocumento.Visible = true;
            }
            else
            {
                labelDataPagamentoDocumento.Visible = false;
                dateTimePickerDataPagamentoDocumento.Visible = false;
            }            
        }

        private void dtPagamentoDocumento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string dataPagamento = (string)dtPagamentoDocumento.CurrentRow.Cells[4].Value;
            if (String.IsNullOrEmpty(dataPagamento) || String.IsNullOrWhiteSpace(dataPagamento))
            {
                dateTimePickerDataPagamentoDocumento2.Visible = true;
                labelDataPagamentoDocumento2.Visible = true;
                btnInformarPagamentoDocumento.Visible = true;
                btnCancelarInformarPagamentoDocumento.Visible = true;
            }                
            else
            {
                dateTimePickerDataPagamentoDocumento2.Visible = false;
                labelDataPagamentoDocumento2.Visible = false;
                btnInformarPagamentoDocumento.Visible = false;
                btnCancelarInformarPagamentoDocumento.Visible = false;
            }
        }

        private void btnInformarPagamentoDocumento_Click(object sender, EventArgs e)
        {
            try
            {
                string dataPagamento = (string)dtPagamentoDocumento.CurrentRow.Cells[4].Value;
                if (String.IsNullOrEmpty(dataPagamento) || String.IsNullOrWhiteSpace(dataPagamento))
                {
                    int id = (int)dtPagamentoDocumento.CurrentRow.Cells[0].Value;
                    pagamentoDocumentoBLL.InformarPagamento(id, dateTimePickerDataPagamentoDocumento2.Value);
                    CarregarGridPagamentoDocumento(dataAtual, veiculo);
                    CarregarDashboard();
                }
                else
                    MessageBox.Show("Este registro já foi pago!", "Pagamento já realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problema ao tentar atualizar a data de pagamento: {ex.Message}", "Pagamento já realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                dateTimePickerDataPagamentoDocumento2.Value = DateTime.Now;
                dateTimePickerDataPagamentoDocumento2.Visible = false;
                labelDataPagamentoDocumento2.Visible = false;
                btnInformarPagamentoDocumento.Visible = false;
                btnCancelarInformarPagamentoDocumento.Visible = false;
            }
        }

        private void btnCancelarInformarPagamentoDocumento_Click(object sender, EventArgs e)
        {
            dateTimePickerDataPagamentoDocumento2.Visible = false;
            labelDataPagamentoDocumento2.Visible = false;
            btnInformarPagamentoDocumento.Visible = false;
            btnCancelarInformarPagamentoDocumento.Visible = false;
        }

        private void PreencherComboBoxCombustivel()
        {
            var combusitiveis = combustivelBLL.GetList();

            //preenche o combo combustivel
            cmbCombustivel.DataSource = combusitiveis;
            cmbCombustivel.DisplayMember = "Tipo";
            cmbCombustivel.ValueMember = "Id";
            cmbCombustivel.SelectedIndex = -1;
        }  

        private void DesabilitarCampos()
        {
            //desativa para edição
            txtRenavam.ReadOnly = true;
            txtCPFCNPJ.ReadOnly = true;
            txtNomeEndereco.ReadOnly = true;
            txtPlaca.ReadOnly = true;
            txtCidade.ReadOnly = true;
            txtCodigoPostal.ReadOnly = true;
            txtChassi.ReadOnly = true;
            txtMarca.ReadOnly = true;
            txtModelo.ReadOnly = true;
            txtAnoFab.ReadOnly = true;
            txtAnoModelo.ReadOnly = true;
            txtCategoria.ReadOnly = true;
            txtCor.ReadOnly = true;
            cmbCombustivel.Enabled = false;
            txtDataAquisicao.ReadOnly = true;
            txtKilometragem.ReadOnly = true;
            txtPotencia.ReadOnly = true;
            txtAnexarDocumento.ReadOnly = true;
            btnAnexarDocumento.Enabled = false;
            btnSalvar.Visible = false;
            btnAlterarVeiculo.Enabled = false;
            txtMedidaPneus.Enabled = false;

            txtRenavam.BackColor = SystemColors.Control;
            txtCPFCNPJ.BackColor = SystemColors.Control;
            txtNomeEndereco.BackColor = SystemColors.Control;
            txtPlaca.BackColor = SystemColors.Control;
            txtCidade.BackColor = SystemColors.Control;
            txtCodigoPostal.BackColor = SystemColors.Control;
            txtChassi.BackColor = SystemColors.Control;
            txtMarca.BackColor = SystemColors.Control;
            txtModelo.BackColor = SystemColors.Control;
            txtAnoFab.BackColor = SystemColors.Control;
            txtAnoModelo.BackColor = SystemColors.Control;
            txtCategoria.BackColor = SystemColors.Control;
            txtCor.BackColor = SystemColors.Control;            
            txtDataAquisicao.BackColor = SystemColors.Control;
            txtKilometragem.BackColor = SystemColors.Control;            
            txtAnexarDocumento.BackColor = SystemColors.Control;
            txtMedidaPneus.BackColor = SystemColors.Control;
        }

        private void HabilitarCampos()
        {
            //ativa para edição
            txtRenavam.ReadOnly = false;
            txtCPFCNPJ.ReadOnly = false;
            txtNomeEndereco.ReadOnly = false;
            txtCidade.ReadOnly = false;
            txtCodigoPostal.ReadOnly = false;
            txtChassi.ReadOnly = false;
            txtAnoFab.ReadOnly = false;
            txtAnoModelo.ReadOnly = false;
            txtCategoria.ReadOnly = false;
            txtCor.ReadOnly = false;
            cmbCombustivel.Enabled = true;
            txtDataAquisicao.ReadOnly = false;
            txtKilometragem.ReadOnly = false;
            txtPotencia.ReadOnly = false;
            txtAnexarDocumento.ReadOnly = false;
            btnAnexarDocumento.Enabled = true;
            btnAlterarVeiculo.Enabled = true;
            txtMedidaPneus.ReadOnly = false;

            txtRenavam.BackColor = Color.White;
            txtCPFCNPJ.BackColor = Color.White;
            txtNomeEndereco.BackColor = Color.White;
            txtCodigoPostal.BackColor = Color.White;
            txtPlaca.BackColor = Color.White;
            txtCidade.BackColor = Color.White;            
            txtChassi.BackColor = Color.White;
            txtMarca.BackColor = Color.White;
            txtModelo.BackColor = Color.White;
            txtAnoFab.BackColor = Color.White;
            txtAnoModelo.BackColor = Color.White;
            txtCategoria.BackColor = Color.White;
            txtCor.BackColor = Color.White;            
            txtDataAquisicao.BackColor = Color.White;
            txtKilometragem.BackColor = Color.White;            
            txtAnexarDocumento.BackColor = Color.White;
            txtMedidaPneus.BackColor = Color.White;
        }

        private void PreencherFormularioDocumento()
        {
            //carrega os valores
            txtRenavam.Text = veiculo.Renavam;
            txtCPFCNPJ.Text = veiculo.CPFCNPJ;
            txtNomeEndereco.Text = veiculo.NomeEndereco;
            txtPlaca.Text = veiculo.Placa;
            txtCidade.Text = veiculo.Cidade;
            txtCodigoPostal.Text = veiculo.CodigoPostal;
            txtChassi.Text = veiculo.Chassi;
            txtMarca.Text = veiculo.FipeNameMarca;
            txtModelo.Text = veiculo.FIPEModelo;
            txtAnoFab.Text = veiculo.AnoFab;
            txtAnoModelo.Text = veiculo.AnoModelo;
            txtCategoria.Text = veiculo.Categoria;
            txtCor.Text = veiculo.Cor;
            cmbCombustivel.SelectedValue = veiculo.Combustivel;
            txtDataAquisicao.Text = veiculo.DataAquisicao;
            txtKilometragem.Text = veiculo.KM.ToString();
            txtPotencia.Text = veiculo.Potencia;
            lblMensagem.Visible = false;
            txtAnexarDocumento.Text = veiculo.PathDocumentoPDF;
            txtMedidaPneus.Text = veiculo.MedidasPneus;
        }

        private bool ValidarCampos()
        {
            lblMensagem.Visible = false;

            if (String.IsNullOrEmpty(txtRenavam.Text) || String.IsNullOrWhiteSpace(txtRenavam.Text))
            {                
                txtRenavam.BackColor = Color.Yellow;
                lblMensagem.Text = "O Renavam deve ser preenchido corretamente!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                txtRenavam.BackColor = Color.White; 
                lblMensagem.Visible = false;
            }

            if (String.IsNullOrEmpty(txtCPFCNPJ.Text) || String.IsNullOrWhiteSpace(txtCPFCNPJ.Text))
            {
                txtCPFCNPJ.BackColor = Color.Yellow;
                lblMensagem.Text = "O CPF/CNPF deve ser preenchido corretamente!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                txtCPFCNPJ.BackColor = Color.White;
                lblMensagem.Visible = false;
            }

            if (String.IsNullOrEmpty(txtNomeEndereco.Text) || String.IsNullOrWhiteSpace(txtNomeEndereco.Text))
            {
                txtNomeEndereco.BackColor = Color.Yellow;
                lblMensagem.Text = "O Nome/Endereço deve ser preenchido corretamente!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                txtNomeEndereco.BackColor = Color.White;
                lblMensagem.Visible = false;
            }

            if (String.IsNullOrEmpty(txtPlaca.Text) || String.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                txtPlaca.BackColor = Color.Yellow;
                lblMensagem.Text = "A Placa deve ser preenchido corretamente!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                txtPlaca.BackColor = Color.White;
                lblMensagem.Visible = false;
            }

            if (String.IsNullOrEmpty(txtCidade.Text) || String.IsNullOrWhiteSpace(txtCidade.Text))
            {
                txtCidade.BackColor = Color.Yellow;
                lblMensagem.Text = "A Cidade deve ser preenchido corretamente!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                txtCidade.BackColor = Color.White;
                lblMensagem.Visible = false;
            }           

            if (String.IsNullOrEmpty(txtChassi.Text) || String.IsNullOrWhiteSpace(txtChassi.Text))
            {
                txtChassi.BackColor = Color.Yellow;
                lblMensagem.Text = "O Chassi ser preenchido corretamente!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                txtChassi.BackColor = Color.White;
                lblMensagem.Visible = false;
            }

            if (String.IsNullOrEmpty(txtMarca.Text) || String.IsNullOrWhiteSpace(txtMarca.Text))
            {
                txtMarca.BackColor = Color.Yellow;
                lblMensagem.Text = "Campo em vermelhor deve ser preenchido corretamente!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                txtMarca.BackColor = Color.White;
                lblMensagem.Visible = false;
            }

            if (String.IsNullOrEmpty(txtModelo.Text) || String.IsNullOrWhiteSpace(txtModelo.Text))
            {
                txtModelo.BackColor = Color.Yellow;
                lblMensagem.Text = "Campo em vermelhor deve ser preenchido corretamente!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                txtModelo.BackColor = Color.White;
                lblMensagem.Visible = false;
            }

            if (String.IsNullOrEmpty(txtAnoFab.Text) || String.IsNullOrWhiteSpace(txtAnoFab.Text))
            {
                txtAnoFab.BackColor = Color.Yellow;
                lblMensagem.Text = "O ano de fabricação deve ser preenchido corretamente!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                txtAnoFab.BackColor = Color.White;
                lblMensagem.Visible = false;
            }

            if (String.IsNullOrEmpty(txtAnoModelo.Text) || String.IsNullOrWhiteSpace(txtAnoModelo.Text))
            {
                txtAnoModelo.BackColor = Color.Yellow;
                lblMensagem.Text = "O ano modelo deve ser preenchido corretamente!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                txtAnoModelo.BackColor = Color.White;
                lblMensagem.Visible = false;
            }

            if (String.IsNullOrEmpty(txtCategoria.Text) || String.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                txtCategoria.BackColor = Color.Yellow;
                lblMensagem.Text = "O ano de fabricação deve ser preenchido corretamente!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                txtCategoria.BackColor = Color.White;
                lblMensagem.Visible = false;
            }

            if (String.IsNullOrEmpty(txtCor.Text) || String.IsNullOrWhiteSpace(txtCor.Text))
            {
                txtCor.BackColor = Color.Yellow;
                lblMensagem.Text = "A cor deve ser preenchido corretamente!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                txtCor.BackColor = Color.White;
                lblMensagem.Visible = false;
            }

            if (String.IsNullOrEmpty(txtPotencia.Text) || String.IsNullOrWhiteSpace(txtPotencia.Text))
            {
                txtPotencia.BackColor = Color.Yellow;
                lblMensagem.Text = "A potência do motor deve ser preenchido corretamente!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                txtPotencia.BackColor = Color.White;
                lblMensagem.Visible = false;
            }

            if (String.IsNullOrEmpty(txtKilometragem.Text) || String.IsNullOrWhiteSpace(txtKilometragem.Text))
            {
                txtKilometragem.BackColor = Color.Yellow;
                lblMensagem.Text = "A Kilometragem deve ser preenchido corretamente!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                txtKilometragem.BackColor = Color.White;
                lblMensagem.Visible = false;
            }

            if (cmbCombustivel.SelectedIndex == -1)
            {
                cmbCombustivel.BackColor = Color.Yellow;
                lblMensagem.Text = "O tipo de combustivel deve ser selecionado!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                cmbCombustivel.BackColor = Color.White;
                lblMensagem.Visible = false;
            }

            return true;
        }

        private void Salvar()
        {
            veiculo.Renavam = txtRenavam.Text;
            veiculo.CPFCNPJ = txtCPFCNPJ.Text;
            veiculo.NomeEndereco = txtNomeEndereco.Text;
            veiculo.Placa = txtPlaca.Text;
            veiculo.Cidade = txtCidade.Text;
            veiculo.CodigoPostal = txtCodigoPostal.Text;
            veiculo.Chassi = txtChassi.Text;
            veiculo.AnoFab = txtAnoFab.Text;
            veiculo.AnoModelo = txtAnoModelo.Text;
            veiculo.Categoria = txtCategoria.Text;
            veiculo.Cor = txtCor.Text;
            veiculo.Combustivel = (int)cmbCombustivel.SelectedValue;
            veiculo.DataAquisicao = txtDataAquisicao.Text;
            veiculo.KM = Convert.ToInt64(txtKilometragem.Text);
            veiculo.Potencia = txtPotencia.Text;
            veiculo.PathDocumentoPDF = txtAnexarDocumento.Text;
            veiculo.MedidasPneus = txtMedidaPneus.Text;

            try
            {
                VerificaPasta(pathDocumentos);
                if (!(String.IsNullOrEmpty(txtAnexarDocumento.Text) && String.IsNullOrWhiteSpace(txtAnexarDocumento.Text)))
                    CopiaComprovante(pathOrigemComprovante, pathDestinoComprovante);
                veiculoBLL.Salvar(veiculo);
            }
            catch (Exception)
            {
                throw;
            }
        }                             

        private void CarregarGridPagamentoDocumento(DateTime dtAtual, Veiculo veiculo)
        {
            dtPagamentoDocumento.DataSource = pagamentoDocumentoBLL.List(dtAtual.Date, veiculo);

            FormartaDataGridViewPagamentoDocumento();
        }

        private void  FormartaDataGridViewPagamentoDocumento()
        {
            ////esconde as colunas desnecessárias
            dtPagamentoDocumento.Columns["Data"].Visible = false;
            dtPagamentoDocumento.Columns["DataVencimento"].Visible = false;
            dtPagamentoDocumento.Columns["Id"].Visible = false;

            //ajusta lagura da coluna            
            dtPagamentoDocumento.Columns["DataVencimentoS"].Width = 80;
            dtPagamentoDocumento.Columns["DataS"].Width = 80;
            dtPagamentoDocumento.Columns["Valor"].Width = 80;
            dtPagamentoDocumento.Columns["Descricao"].Width = 200;

            //ajusta o texto header do grid            
            dtPagamentoDocumento.Columns["DataS"].HeaderText = "Data Pag.";
            dtPagamentoDocumento.Columns["DataVencimentoS"].HeaderText = "Data Ven.";
            dtPagamentoDocumento.Columns["Descricao"].HeaderText = "Descrição";
        }


        #endregion

        #region Aba Seguro

        private void btnAtivarContrato_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmAddContratoSeguro frm = new frmAddContratoSeguro(veiculo))
                {
                    frm.ShowDialog();
                    contratoSeguro = frm.Contrato;
                }

                CarregarContratoSeguro();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao ativar um contrato. {ex.Message}", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnexarComprovantePagaSeguro_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new OpenFileDialog();

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathOrigemComprovante = this.openFileDialog1.FileName;
                fileNameComprovante = this.openFileDialog1.SafeFileName;
                pathDestinoComprovante = Path.Combine(pathSeguro, fileNameComprovante);
                txtPathAnexarComprovantePagaSeguro.Text = pathOrigemComprovante;
            }
        }

        private void btnEncerrarContrato_Click(object sender, EventArgs e)
        {
            try
            {
                contratoSeguradoraBLL.EncerrarContrato(contratoSeguro);
                CarregarContratoSeguro();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao encerrar contrato. {ex.Message}", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLancarPagaSeguro_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtPathAnexarComprovantePagaSeguro.Text) || !String.IsNullOrWhiteSpace(txtPathAnexarComprovantePagaSeguro.Text))
                {
                    VerificaPasta(pathSeguro);
                    CopiaComprovante(pathOrigemComprovante, pathDestinoComprovante);
                }

                PagamentosSeguro pagamento = new PagamentosSeguro
                {
                    ContratoSeguro = contratoSeguro,
                    ContratoSeguroId = contratoSeguro.Id,
                    DataPagamento = dateTimePickerPagamentoSeguro.Value.Date,
                    Valor = Convert.ToDecimal(txtValorPagamentoSeguro.Text),
                    Veiculo = veiculo,
                    VeiculoID = veiculo.Placa,
                    PathPagamentoPDF = fileNameComprovante
                };

                contratoSeguradoraBLL.InsertPagamento(pagamento);

                txtValorPagamentoSeguro.Clear();
                dateTimePickerPagamentoSeguro.Value = DateTime.Now;
                txtPathAnexarComprovantePagaSeguro.Clear();
                dtPagamentoSeguro.DataSource = contratoSeguradoraBLL.ListPagamentos(contratoSeguro.DataInicialContrato, contratoSeguro.DataFinalContrato, veiculo, contratoSeguro);
                FormartaDataGridViewPagamentoSeguro();
                CarregarDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao inserir pagamento do seguro. {ex.Message}", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVisualizarComprovantePagaSegu_Click(object sender, EventArgs e)
        {
            string fileNameCompro = (string)dtPagamentoSeguro.CurrentRow.Cells[4].Value;
            if (String.IsNullOrEmpty(fileNameCompro) || String.IsNullOrWhiteSpace(fileNameCompro))
                MessageBox.Show("Este registro não possui comprovante anexado.", "Sem comprovante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                try
                {
                    pathDestinoComprovante = Path.Combine(pathSeguro, fileNameCompro);
                    Process.Start(pathDestinoComprovante);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Falha ao localizar comprovante. {ex.Message}", "Sem comprovante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnAplicarFiltroPagamentoSeguro_Click(object sender, EventArgs e)
        {
            if (ckDataSeguro.Checked && !ckSeguradora.Checked)
            {
                dtPagamentoSeguro.DataSource = contratoSeguradoraBLL.ListPagamentos(dateTimePickerInicialFiltroSeguro.Value.Date, dateTimePickerFinalFiltroSeguro.Value.Date, veiculo);
                FormartaDataGridViewPagamentoSeguro();
            }

            if (!ckDataSeguro.Checked && ckSeguradora.Checked)
            {
                if (cmbFiltroSeguradora.SelectedIndex == -1)
                {
                    MessageBox.Show($"Selecione uma seguradora!", "Seguradora não selecionada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    dtPagamentoSeguro.DataSource = contratoSeguradoraBLL.ListPagamentos((int)cmbFiltroSeguradora.SelectedValue, veiculo);
                    FormartaDataGridViewPagamentoSeguro();
                }
            }

            if (ckDataSeguro.Checked && ckSeguradora.Checked)
            {
                if (cmbFiltroSeguradora.SelectedIndex == -1)
                {
                    MessageBox.Show($"Selecione uma seguradora!", "Seguradora não selecionada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    dtPagamentoSeguro.DataSource = contratoSeguradoraBLL.ListPagamentos((int)cmbFiltroSeguradora.SelectedValue, dateTimePickerInicialFiltroSeguro.Value.Date, dateTimePickerFinalFiltroSeguro.Value.Date, veiculo, contratoSeguro);
                    FormartaDataGridViewPagamentoSeguro();
                }
            }
        }

        private void CarregarComboBoxFiltroSeguradora()
        {
            try
            {
                seguradoras = seguradoraBLL.ListDt();

                //preenche o combo carros
                cmbFiltroSeguradora.DataSource = seguradoras;
                cmbFiltroSeguradora.DisplayMember = "Nome";
                cmbFiltroSeguradora.ValueMember = "id";
                cmbFiltroSeguradora.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problemas ao consultar dados: {ex.Message}", "Falha de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarContratoSeguro()
        {
            contratoSeguro = contratoSeguradoraBLL.GetSeguroAtivo();

            if (contratoSeguro != null)
            {
                dtPagamentoSeguro.DataSource = contratoSeguradoraBLL.ListPagamentos(contratoSeguro.DataInicialContrato.Date, contratoSeguro.DataFinalContrato.Date, veiculo, contratoSeguro);
                FormartaDataGridViewPagamentoSeguro();
                txtNumeroContratoSeguro.Text = contratoSeguro.NumeroApolice;
                txtSeguradora.Text = contratoSeguro.Seguradora.Nome;
                txtCorretorSeguro.Text = contratoSeguro.Seguradora.Corretor;
                txtDataInicialContratoSeguro.Text = contratoSeguro.DataInicialContrato.ToShortDateString();
                txtDataFinalContratoSeguro.Text = contratoSeguro.DataFinalContrato.ToShortDateString();
                txtPathCartaoSeguro.Text = contratoSeguro.PathCartaoPDF;
                txtPathOrcamentoSeguro.Text = contratoSeguro.PathOrcamentoPDF;
                btnAtivarContrato.Visible = false;
                btnEncerrarContrato.Visible = true;
                btnEncerrarContrato.Location = new Point(180, 10);
                groupBoxInserirPagamentoSeguro.Visible = true;
                btnRenovarSeguro.Visible = true;
            }
            else
            {
                dtPagamentoSeguro.DataSource = contratoSeguradoraBLL.ListPagamentos(dataInicialAtual.Date, dataFinalAtual.Date, veiculo);
                FormartaDataGridViewPagamentoSeguro();
                groupBoxInserirPagamentoSeguro.Visible = false;
                btnRenovarSeguro.Visible = false;
                btnEncerrarContrato.Visible = false;
                txtNumeroContratoSeguro.Clear();
                txtSeguradora.Clear();
                txtCorretorSeguro.Clear();
                txtDataInicialContratoSeguro.Clear();
                txtDataFinalContratoSeguro.Clear();
                txtPathCartaoSeguro.Clear();
                txtPathOrcamentoSeguro.Clear();
            }
        }       

        private void btnAnexarOrcamentoSeguro_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPathOrcamentoSeguro.Text) || String.IsNullOrWhiteSpace(txtPathOrcamentoSeguro.Text))
            {
                using (this.openFileDialog1 = new OpenFileDialog())
                {
                    if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        pathOrigemOrcamentoSeguro = this.openFileDialog1.FileName;
                        fileNameOrcamentoSeguro = this.openFileDialog1.SafeFileName;
                        pathDestinoOrcamentoSeguro = Path.Combine(pathSeguro, fileNameOrcamentoSeguro);
                        txtPathOrcamentoSeguro.Text = pathOrigemOrcamentoSeguro;
                        btnSalvarAlteracoesSeguro.Visible = true;
                    }
                }
            }
            else
            {
                if (MessageBox.Show($"Já existe um arquivo anexado, deseja substituir por outro?", "Já existe anexo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    using (this.openFileDialog1 = new OpenFileDialog())
                    {
                        if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            pathOrigemOrcamentoSeguro = this.openFileDialog1.FileName;
                            fileNameOrcamentoSeguro = this.openFileDialog1.SafeFileName;
                            pathDestinoOrcamentoSeguro = Path.Combine(pathSeguro, fileNameOrcamentoSeguro);
                            txtPathOrcamentoSeguro.Text = pathOrigemOrcamentoSeguro;
                            btnSalvarAlteracoesSeguro.Visible = true;
                        }
                    }
                }
            }
        }

        private void btnAnexarCartaoSeguro_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPathCartaoSeguro.Text) || String.IsNullOrWhiteSpace(txtPathCartaoSeguro.Text))
            {
                using (this.openFileDialog1 = new OpenFileDialog())
                {
                    if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        pathOrigemCartaoSeguro = this.openFileDialog1.FileName;
                        fileNameCartaoSeguro = this.openFileDialog1.SafeFileName;
                        pathDestinoCartaoSeguro = Path.Combine(pathSeguro, fileNameComprovante);
                        txtPathCartaoSeguro.Text = pathOrigemCartaoSeguro;
                        btnSalvarAlteracoesSeguro.Visible = true;
                    }
                }
            }
            else
            {
                if (MessageBox.Show($"Já existe um arquivo anexado, deseja substituir por outro?", "Já existe anexo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    using (this.openFileDialog1 = new OpenFileDialog())
                    {
                        if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            pathOrigemCartaoSeguro = this.openFileDialog1.FileName;
                            fileNameCartaoSeguro = this.openFileDialog1.SafeFileName;
                            pathDestinoCartaoSeguro = Path.Combine(pathSeguro, fileNameComprovante);
                            txtPathCartaoSeguro.Text = pathOrigemCartaoSeguro;
                            btnSalvarAlteracoesSeguro.Visible = true;
                        }
                    }
                }
            }
        }

        private void btnSalvarAlteracoesSeguro_Click(object sender, EventArgs e)
        {
            try
            {
                VerificaPasta(pathSeguro);

                if (!String.IsNullOrEmpty(txtPathOrcamentoSeguro.Text) || !String.IsNullOrWhiteSpace(txtPathOrcamentoSeguro.Text))
                {
                    CopiaComprovante(pathOrigemOrcamentoSeguro, pathDestinoOrcamentoSeguro);
                }

                if (!String.IsNullOrEmpty(txtPathCartaoSeguro.Text) || !String.IsNullOrWhiteSpace(txtPathCartaoSeguro.Text))
                {
                    CopiaComprovante(pathOrigemCartaoSeguro, pathDestinoCartaoSeguro);
                }

                contratoSeguro.PathCartaoPDF = fileNameCartaoSeguro;
                contratoSeguro.PathOrcamentoPDF = fileNameOrcamentoSeguro;

                contratoSeguradoraBLL.EditarAnexos(contratoSeguro);

                btnSalvarAlteracoesSeguro.Visible = false;
                MessageBox.Show($"Anexos alterados com sucesso!", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao salvar anexo(s). {ex.Message}", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormartaDataGridViewPagamentoSeguro()
        {
            ////esconde as colunas desnecessárias
            dtPagamentoSeguro.Columns["Id"].Visible = false;
            //dtAbastecimento.Columns["Id"].Visible = false;
            //dtAbastecimento.Columns["Revisao"].Visible = false;

            //ajusta lagura da coluna   
            dtPagamentoSeguro.Columns["Id"].Width = 80;
            dtPagamentoSeguro.Columns["Apolice"].Width = 130;
            dtPagamentoSeguro.Columns["Data"].Width = 130;
            dtPagamentoSeguro.Columns["Valor"].Width = 80;
            dtPagamentoSeguro.Columns["PathComprovantePDF"].Width = 255;

            //ajusta o texto header do grid
            //dtOleo.Columns["PathComprovantePDF"].HeaderText = "Comprovante";
        }

        #endregion

        #region Aba Multa

        private void btnLancarMulta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtPathMulta.Text) || !String.IsNullOrWhiteSpace(txtPathMulta.Text))
                {
                    VerificaPasta(pathMultas);
                    CopiaComprovante(pathOrigemMulta, pathDestinoMulta);
                }

                Multa multa = new Multa
                {
                    DataOcorrencia = dateTimePickerOcorrenciaMulta.Value.Date,
                    DataVencimento = dateTimePickerVencimentoMulta.Value.Date,
                    Valor = Convert.ToDecimal(txtValorMulta.Text),
                    LocalOcorrencia = txtLocalOcorrenciaMulta.Text,
                    PagamentoRealizado = ckPagamentoRealizado.Checked,
                    PathAnexoMultaPDF = fileNameMulta,
                    VeiculoID = veiculo.Placa,
                    Veiculo = veiculo,
                    DataPagamento = new DateTime(2000,01,01)
                };

                multaBLL.Insert(multa);

                dateTimePickerOcorrenciaMulta.Value = DateTime.Now;
                dateTimePickerVencimentoMulta.Value = DateTime.Now;
                txtValorMulta.Clear();
                txtLocalOcorrenciaMulta.Clear();
                txtPathMulta.Clear();
                ckPagamentoRealizado.Checked = false;
                CarregarDatagridMulta(veiculo);
                CarregarDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir multa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnexarMulta_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new OpenFileDialog();

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathOrigemMulta = this.openFileDialog1.FileName;
                fileNameMulta = this.openFileDialog1.SafeFileName;
                pathDestinoMulta = Path.Combine(pathMultas, fileNameMulta);
                txtPathMulta.Text = pathOrigemMulta;
            }
        }

        private void btnAdicionarMulta_Click(object sender, EventArgs e)
        {
            string fileNameMulta = (string)dtMultas.CurrentRow.Cells[10].Value;
            if (String.IsNullOrEmpty(fileNameMulta) || String.IsNullOrWhiteSpace(fileNameMulta))
            {
                int id = (int)dtMultas.CurrentRow.Cells[0].Value;
                frmAdicionarComprovante frm = new frmAdicionarComprovante(id, TipoAnexo.Multa);
                frm.ShowDialog();
                CarregarDatagridMulta(veiculo);
            }
            else
            {
                MessageBox.Show("Este registro já possui comprovante anexado.", "Comprovante já anexado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnVisualizaMulta_Click(object sender, EventArgs e)
        {
            string fileNameMulta = (string)dtMultas.CurrentRow.Cells[10].Value;
            if (String.IsNullOrEmpty(fileNameMulta) || String.IsNullOrWhiteSpace(fileNameMulta))
                MessageBox.Show("Este registro não possui multa anexada.", "Sem multa anexada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                try
                {
                    pathDestinoMulta = Path.Combine(pathMultas, fileNameMulta);
                    Process.Start(pathDestinoMulta);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Falha ao localizar multa. {ex.Message}", "Sem multa anexada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnAplicarFiltroMulta_Click(object sender, EventArgs e)
        {
            int tipoStatusMulta = 0;

            if (rdPagas.Checked)
                tipoStatusMulta = 2;
            else if (rdNaoPagas.Checked)
                tipoStatusMulta = 1;
            else if (rdAmbas.Checked)
                tipoStatusMulta = 0;
            else
                tipoStatusMulta = 0;


            dtMultas.DataSource = multaBLL.List(dateTimePickerFiltroInicialMulta.Value.Date, dateTimePickerFiltroFinalMulta.Value.Date, tipoStatusMulta, cmbFiltroDataMultaPor.SelectedIndex, veiculo);
            FormartaDataGridViewMulta();

        }

        private void btnInformarPagamento_Click(object sender, EventArgs e)
        {
            string statusPagamento = (string)dtMultas.CurrentRow.Cells[4].Value;
            if (!String.IsNullOrEmpty(statusPagamento) && !String.IsNullOrWhiteSpace(statusPagamento))
            {
                int id = (int)dtMultas.CurrentRow.Cells[0].Value;

                multaBLL.SetPagamento(id, dateTimePickerDataPagamentoMulta.Value);
                CarregarDatagridMulta(veiculo);
                CarregarDashboard();
            }
            else
            {
                MessageBox.Show("Multa já foi paga!", "Multa paga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnResetFiltro_Click(object sender, EventArgs e)
        {
            CarregarDatagridMulta(veiculo);
        }

        private void CarregarDatagridMulta(Veiculo veiculo)
        {
            dtMultas.DataSource = multaBLL.List(veiculo);

            FormartaDataGridViewMulta();
        }

        private void FormartaDataGridViewMulta()
        {
            ////esconde as colunas desnecessárias
            dtMultas.Columns["DataOcorrencia"].Visible = false;
            dtMultas.Columns["DataVencimento"].Visible = false;
            dtMultas.Columns["DataPagamento"].Visible = false;

            //ajusta lagura da coluna
            dtMultas.Columns["Id"].Width = 50;
            dtMultas.Columns["DataOcorrenciaS"].Width = 100;
            dtMultas.Columns["LocalComplemento"].Width = 288;
            dtMultas.Columns["DataVencimentoS"].Width = 100;
            dtMultas.Columns["DataPagamentoS"].Width = 100;
            dtMultas.Columns["Valor"].Width = 80;
            dtMultas.Columns["Status"].Width = 80;
            dtMultas.Columns["PathComprovantePDF"].Width = 212;

            //ajusta o texto header do grid
            dtMultas.Columns["DataOcorrenciaS"].HeaderText = "Data Ocorrê.";
            dtMultas.Columns["DataVencimentoS"].HeaderText = "Data Venci.";
            dtMultas.Columns["DataPagamentoS"].HeaderText = "Data Paga.";
            dtMultas.Columns["PathComprovantePDF"].HeaderText = "Comprovante da multa";
            dtMultas.Columns["LocalComplemento"].HeaderText = "Local ocorrência";
        }

        #endregion

        private void VerificaPasta(string path)
        {
            //Verifica se existe, senão cria   
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }

        private void CopiaComprovante(string fileOrigem, string fileDestino)
        {
            try
            {
                File.SetAttributes(fileOrigem, FileAttributes.Normal);
                File.Copy(fileOrigem, fileDestino, false);
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show($"Diretório de origem ou de destino não foi encontrado! {ex.Message}", "Diretório não localizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Não foi possivel localizar o arquivo! {ex.Message}", "Arquivo não localizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show($"Arquivo está no formato invalido! {ex.Message}", "Arquivo não localizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                if (MessageBox.Show("Arquivo já existe! Repetir para vincular este registro com o comprovante existente, ou Cancelar para renomear o arquivo", "Arquivo já existe com este nome", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Retry)
                {
                    File.SetAttributes(fileOrigem, FileAttributes.Normal);
                    File.Copy(fileOrigem, fileDestino, true);
                }
                else
                {
                    frmRenomearArquivo frmAlterar = new frmRenomearArquivo(fileNameComprovante);
                    frmAlterar.ShowDialog();

                    if (frmAlterar.FileName != null)
                    {
                        var destino = Path.Combine(pathComprovante, frmAlterar.FileName);
                        fileNameComprovante = frmAlterar.FileName;
                        CopiaComprovante(fileOrigem, destino);
                    }
                }
            }
        }
    }
}
