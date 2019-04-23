using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
//
using www.myAplication;

namespace www
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        //MY METHODS_UI - CLIENTE 

        private void Method_UI_SetComboCompany_Client_tab1(bool x)
        {
            var cliApp = new myClientAplication();
            my_cbx_Empresa_consultacliente_tab1.ValueMember = "company";
            my_cbx_Empresa_consultacliente_tab1.DisplayMember = "company";
            my_cbx_Empresa_consultacliente_tab1.DataSource = cliApp.Method_APP_SelectAll_Company();
            my_cbx_Empresa_consultacliente_tab1.Enabled = x;
        }

        private void Method_UI_SetComboCompany_Client_tab3(bool x)
        {
            var cliApp = new myClientAplication();
            my_cbx_Empresa_consultacliente_tab3.ValueMember = "company";
            my_cbx_Empresa_consultacliente_tab3.DisplayMember = "company";
            my_cbx_Empresa_consultacliente_tab3.DataSource = cliApp.Method_APP_SelectAll_Company();
            my_cbx_Empresa_consultacliente_tab3.Enabled = x;
        }

        private void Method_UI_SetCountSelecRow_Client_tab1(int count)
        {
            my_lb_ContaResultados_consultacliente_tab1.Text = count.ToString();
        }

        private void Method_UI_SetCountSelecRow_Client_tab3(int count)
        {
            if (count > 0)
            {
                my_bt_Limpar_consultacliente_tab3.Enabled = true;
            }
            my_lb_ContaResultados_consultacliente_tab3.Text = count.ToString();
        }

        private void Method_UI_SetClientForOrder_Client_tab1( )
        {

            my_txt_Cod_selecionadocliente_tab1.Text = my_DataGridView_Cliente_tab1.CurrentRow.Cells[0].Value.ToString();
            my_txt_PrimeiroNome_selecionadocliente_tab1.Text = my_DataGridView_Cliente_tab1.CurrentRow.Cells[1].Value.ToString();
            my_txt_UltimoNome_selecionadocliente_tab1.Text = my_DataGridView_Cliente_tab1.CurrentRow.Cells[2].Value.ToString();
            my_txt_Empresa_selecionadocliente_tab1.Text = my_DataGridView_Cliente_tab1.CurrentRow.Cells[3].Value.ToString();

            Method_UI_ClearGrid_Client_tab1();

            my_gbx_ClienteSelecionado_tab1.Enabled = true;
            my_gbx_ConsultaPrato_tab1.Enabled = true;
            my_gbx_Pedido_tab1.Enabled = true;

        }

        private void Method_UI_ClearGrid_Client_tab1()
        {
            var cliApp = new myClientAplication();
            this.my_DataGridView_Cliente_tab1.DataSource = cliApp.Method_APP_ResetList();
            this.my_DataGridView_Cliente_tab1.ClearSelection();
            my_lb_ContaResultados_consultacliente_tab1.Text = "0";
            my_DataGridView_Cliente_tab1.Enabled = false;
            //LIMPA COMBO
            my_cbx_Empresa_consultacliente_tab1.DataSource = null;
            my_cbx_Empresa_consultacliente_tab1.Enabled = false;
            //UNCHEKED CHECKS ELEMENTS
            my_ck_Empresa_consultacliente_tab1.Checked = false;
            my_ck_PrimeiroNome_consultacliente_tab1.Checked = false;
        }

        private void Method_UI_ClearGrid_Cliente_tab3()
        {
            var cliApp = new myClientAplication();
            this.my_DataGridView_Cliente_tab3.AutoGenerateColumns = false;
            this.my_DataGridView_Cliente_tab3.DataSource = cliApp.Method_APP_ResetList();
            this.my_DataGridView_Cliente_tab3.ClearSelection();
            my_lb_ContaResultados_consultacliente_tab3.Text = "0";
            my_DataGridView_Cliente_tab3.Enabled = false;
            //
            //LIMPA COMBO
            my_cbx_Empresa_consultacliente_tab3.DataSource = null;
            my_cbx_Empresa_consultacliente_tab3.Enabled = false;
            //UNCHEKED CHECKS ELEMENTS
            my_ck_Cod_consultacliente_tab3.Checked = false;
            my_ck_Empresa_consultacliente_tab3.Checked = false;
            my_ck_PrimeiroNome_consultacliente_tab3.Checked = false;
            //
            my_bt_Limpar_consultacliente_tab3.Enabled = false;
        }

        private void Method_UI_SetClientFor_Edit_tab3()
        {
           
            my_txt_Cod_novo_tab3.Text = my_DataGridView_Cliente_tab3.CurrentRow.Cells[0].Value.ToString();
            my_txt_PrimeiroNome_novo_tab3.Enabled = true;
            my_txt_PrimeiroNome_novo_tab3.Text = my_DataGridView_Cliente_tab3.CurrentRow.Cells[1].Value.ToString();
            my_txt_UltimoNome_novo_tab3.Enabled = true;
            my_txt_UltimoNome_novo_tab3.Text = my_DataGridView_Cliente_tab3.CurrentRow.Cells[2].Value.ToString();
            my_cbx_Sexo_novo_tab3.Enabled = true;
            string x = my_DataGridView_Cliente_tab3.CurrentRow.Cells[3].Value.ToString();
            if (x == "M")
            {
                my_cbx_Sexo_novo_tab3.SelectedIndex = 0;
            }
            else if (x == "F")
            {
                my_cbx_Sexo_novo_tab3.SelectedIndex = 1;
            }
            
            my_txt_Empresa_novo_tab3.Enabled = true;
            my_txt_Empresa_novo_tab3.Text = my_DataGridView_Cliente_tab3.CurrentRow.Cells[4].Value.ToString();

            Method_UI_ClearGrid_Cliente_tab3();
            //
            my_bt_Salvar_tab3.Enabled = true;
            //
            my_txt_PrimeiroNome_novo_tab3.Focus();
        }

        private void Method_UI_Save_Cliente()
        {
            var clientApp = new myClientAplication();
            int count = clientApp.Method_APP_SelectCount_IfExists(Convert.ToInt32(my_txt_Cod_novo_tab3.Text.ToString()));
            clientApp.Method_APP_Insert_Update(Convert.ToInt32(my_txt_Cod_novo_tab3.Text.ToString()), my_txt_PrimeiroNome_novo_tab3.Text.ToString(), my_txt_UltimoNome_novo_tab3.Text.ToString(), my_cbx_Sexo_novo_tab3.SelectedItem.ToString(), my_txt_Empresa_novo_tab3.Text.ToString());
            if (count == 0)
            {
                MessageBox.Show("Novo cliente inserido com sucesso!");
            }
            else if (count == 1)
            {
                MessageBox.Show("Alteração no cliente feita com sucesso!");
            }

            my_txt_Cod_novo_tab3.Text = null;
            my_txt_Cod_novo_tab3.Enabled = false;
            my_txt_PrimeiroNome_novo_tab3.Text = null;
            my_txt_PrimeiroNome_novo_tab3.Enabled = false;
            my_txt_UltimoNome_novo_tab3.Text = null;
            my_txt_UltimoNome_novo_tab3.Enabled = false;
            my_cbx_Sexo_novo_tab3.Enabled = false;
            my_cbx_Sexo_novo_tab3.SelectedIndex = -1;
            my_txt_Empresa_novo_tab3.Enabled = false;
            my_txt_Empresa_novo_tab3.Text = null;
            //
            my_bt_Salvar_tab3.Enabled = false;
            //
            my_bt_Buscar_consultacliente_tab3.Focus();
        }

        private void Method_UI_Delete_Client()
        {
            var clientApp = new myClientAplication();
            if (MessageBox.Show("Sim ou Não", "Deseja deletar esse prato?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                clientApp.Method_APP_Delete(Convert.ToInt32(my_DataGridView_Cliente_tab3.CurrentRow.Cells[0].Value.ToString()));
                Method_UI_ClearGrid_Cliente_tab3();
            }
        }



        //MY METHODS_UI - FOOD 

        private void Method_UI_Save_Food()
        {
            var foodApp = new myFoodAplication();
            int count = foodApp.Method_APP_SelectCount_IfExists(Convert.ToInt32(my_txt_Cod_novo_tab2.Text.ToString()));
            foodApp.Method_APP_Insert_Update(Convert.ToInt32(my_txt_Cod_novo_tab2.Text.ToString()), my_txt_NomePrato_novo_tab2.Text.ToString(), my_cbx_Porcao_novo_tab2.SelectedItem.ToString(), Convert.ToDouble(my_txt_Preco_novo_tab2.Text.ToString()));
            if (count == 0)
            {
                MessageBox.Show("Novo prato inserido com sucesso!");
            }
            else if (count == 1)
            {
                MessageBox.Show("Alteração no prato feita com sucesso!");
            }

            my_txt_Cod_novo_tab2.Text = null;
            my_txt_Cod_novo_tab2.Enabled = false;
            my_txt_NomePrato_novo_tab2.Text = null;
            my_txt_NomePrato_novo_tab2.Enabled = false;
            my_txt_Preco_novo_tab2.Text = null;
            my_cbx_Porcao_novo_tab2.Enabled = false;
            my_cbx_Porcao_novo_tab2.SelectedIndex = -1;
            my_txt_Preco_novo_tab2.Enabled = false;
            my_txt_Preco_novo_tab2.Text = null;
            //
            my_bt_Salvar_tab2.Enabled = false;
            //
            my_bt_Buscar_consultaprato_tab2.Focus();
        }

        private void Method_UI_Delete_Food()
        {
            var foodApp = new myFoodAplication();
            if (MessageBox.Show("Sim ou Não", "Deseja deletar esse prato?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                foodApp.Method_APP_Delete(Convert.ToInt32(my_DataGridView_Prato_tab2.CurrentRow.Cells[0].Value.ToString()));
                Method_UI_ClearGrid_Food_tab2();
            }
        }

        private List<string> Method_UI_CreateListDistributionGroup()
        {
            var listIdDistribution = new List<string>();
            if (my_DataGridView_Prato_tab1.SelectedRows.Count > 0)
            {
                int lengthRows = Convert.ToInt32(my_DataGridView_Prato_tab1.RowCount.ToString()) ;
                for (int i = 0; i < lengthRows; i++)
                {
                    if (my_DataGridView_Prato_tab1.Rows[i].Selected)
                    {
                        listIdDistribution.Add(my_DataGridView_Prato_tab1.Rows[i].Cells[0].Value.ToString());
                    }
                }
            }
            return listIdDistribution;
        }

        private void Method_UI_AddForListOrder_Food()
        {
            my_DataGridView_Pedido_tab1.AutoGenerateColumns = false;
            my_DataGridView_Pedido_tab1.Enabled = true;
            my_DataGridView_Pedido_tab1.ClearSelection();
            this.my_DataGridView_Pedido_tab1.Rows.Add(my_DataGridView_Prato_tab1.CurrentRow.Cells[0].Value.ToString(), my_DataGridView_Prato_tab1.CurrentRow.Cells[1].Value.ToString(), my_DataGridView_Prato_tab1.CurrentRow.Cells[2].Value.ToString());
        }

        private void Method_UI_SetFoodFor_Edit_tab2()
        {
            my_txt_NomePrato_novo_tab2.Enabled = true;
            my_txt_Cod_novo_tab2.Text = my_DataGridView_Prato_tab2.CurrentRow.Cells[0].Value.ToString();
            my_cbx_Porcao_novo_tab2.Enabled = false;
            my_txt_NomePrato_novo_tab2.Text = my_DataGridView_Prato_tab2.CurrentRow.Cells[1].Value.ToString();

            my_cbx_Porcao_novo_tab2.Enabled = true;
            string x = my_DataGridView_Prato_tab2.CurrentRow.Cells[2].Value.ToString();
            if (x == "(P)")
            {
                my_cbx_Porcao_novo_tab2.SelectedIndex = 0;
            }
            else if (x == "(M)")
            {
                my_cbx_Porcao_novo_tab2.SelectedIndex = 1;
            }
            else if (x == "(N)")
            {
                my_cbx_Porcao_novo_tab2.SelectedIndex = 2;
            }
            else if (x == "(G)")
            {
                my_cbx_Porcao_novo_tab2.SelectedIndex = 3;
            }
            else if (x == "(-)")
            {
                my_cbx_Porcao_novo_tab2.SelectedIndex = 4;
            }

            my_txt_Preco_novo_tab2.Enabled = true;
            my_txt_Preco_novo_tab2.Text = my_DataGridView_Prato_tab2.CurrentRow.Cells[3].Value.ToString();

            Method_UI_ClearGrid_Food_tab2();
            //
            my_bt_Salvar_tab2.Enabled = true;
            //
            my_txt_NomePrato_novo_tab2.Focus();
        }

        private void Method_UI_ClearGrid_Food_tab1()
        {
            var foodApp = new myFoodAplication();
            this.my_DataGridView_Prato_tab1.DataSource = foodApp.Method_APP_ResetList();
            this.my_DataGridView_Prato_tab1.ClearSelection();
            this.my_DataGridView_Prato_tab1.Enabled = false;
            my_lb_ContaResultados_consultaprato_tab1.Text = "0";
            //
            my_ck_Cod_consultaprato_tab1.Checked = false;
            my_ck_NomePrato_consultaprato_tab1.Checked = false;
        }

        private void Method_UI_ClearGrid_Food_tab2()
        {
            var foodApp = new myFoodAplication();
            this.my_DataGridView_Prato_tab2.DataSource = foodApp.Method_APP_ResetList();
            this.my_DataGridView_Prato_tab2.ClearSelection();
            this.my_DataGridView_Prato_tab2.Enabled = false;
            my_lb_ContaResultados_consultaprato_tab2.Text = "0";
            //
            my_ck_Cod_consultaprato_tab2.Checked = false;
            my_ck_NomePrato_consultaprato_tab2.Checked = false;
            //
            my_ck_Porcao_consultaprato_tab2.Checked = false;
            my_cbx_Porcao_consulta_tab2.SelectedIndex = -1;
            my_cbx_Porcao_consulta_tab2.Enabled = false;
            //
            my_bt_Limpar_consultaprato_tab2.Enabled = false;
        }

        private void Method_UI_SetCountSelecRow_Food_tab1(int count)
        {
              my_lb_ContaResultados_consultaprato_tab1.Text = count.ToString();
        }

        private void Method_UI_SetCountSelecRow_Food_tab2(int count)
        {
            if (count>0)
            {
                my_bt_Limpar_consultaprato_tab2.Enabled = true;
            }
            my_lb_ContaResultados_consultaprato_tab2.Text = count.ToString();
        }

        private List<int> Method_UI_CreateListId_Food()
        {
            int countRow = Convert.ToInt32(my_DataGridView_Pedido_tab1.Rows.Count.ToString());
            var listIdFood = new List<int>();
            for (int i = 0; i < countRow; i++)
            {
                listIdFood.Add(Convert.ToInt32(my_DataGridView_Pedido_tab1.Rows[i].Cells[0].Value.ToString()));
            }
            return listIdFood;
        }



        //MY METHODS_UI - ORDER

        private void Method_UI_ClearGrid_Order_tab1()
        {
            this.my_DataGridView_Pedido_tab1.AutoGenerateColumns = false;
            var orderApp = new myOrderAplication();
            this.my_DataGridView_Pedido_tab1.DataSource = orderApp.Method_APP_ResetList();
            this.my_DataGridView_Pedido_tab1.ClearSelection();
            this.my_DataGridView_Pedido_tab1.Enabled = false;
        }

        private void Method_UI_SetCountSelecRow_Order_tab1(int count)
        {
            if (count>0)
            {
                my_bt_Finalizar_Pedido_tab1.Enabled = true;
            }
            else
            {
                my_bt_Finalizar_Pedido_tab1.Enabled = false;
            }
            my_lb_Contador_Pedido_tab1.Text = count.ToString();
        }

        private void Method_UI_Cancel_Order()
        {
            Method_UI_SetCountSelecRow_Order_tab1(my_DataGridView_Pedido_tab1.Rows.Count);
            Method_UI_ClearGrid_Order_tab1();
            Method_UI_ClearGrid_Food_tab1();
            Method_UI_ClearGrid_Client_tab1();
            //
            my_gbx_Observacoes_tab1.Enabled = false;
            my_gbx_Pedido_tab1.Enabled = false;
            my_gbx_ConsultaPrato_tab1.Enabled = false;
            my_gbx_ConsultaClient_tab1.Enabled = false;
            my_gbx_ClienteSelecionado_tab1.Enabled = false;
            //
            my_txt_Observacoes_Pedido_tab1.Text = null;
            //
            my_txt_Cod_selecionadocliente_tab1.Text = null;
            my_txt_PrimeiroNome_selecionadocliente_tab1.Text = null;
            my_txt_UltimoNome_selecionadocliente_tab1.Text = null;
            my_txt_Empresa_selecionadocliente_tab1.Text = null;
            //
            my_txt_NumeroPedido_tab1.Text = null;
            my_txt_NumeroPedido_tab1.Enabled = false;
            //
            my_bt_Cancelar_tab1.Enabled = false;
            //
            my_bt_Novo_tab1.Focus();
        }

        private void Method_UI_Finish_Order()
        {
            var orderApp = new myOrderAplication();
            if (MessageBox.Show("Sim ou Não", "Deseja finalizar esse pedido?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                int idClient = Convert.ToInt32(my_txt_Cod_selecionadocliente_tab1.Text);
                string note = my_txt_Observacoes_Pedido_tab1.Text.ToString();
                double price = orderApp.Method_APP_CalcSumPrice(Method_UI_CreateListId_Food());
                orderApp.Method_APP_Insert_Order(idClient, note, price, Method_UI_CreateListId_Food());

                Method_UI_Cancel_Order();
            }
        }
        
        // MY METHODS_UI HISTORICO ORDER
        private void Method_UI_SetCountSelecRow_Client_tab4(int count)
        {
            my_lb_ContaResultados_consultapedido_tab4.Text = count.ToString();
        }


        // EVENT LOAD WINDOW
        private void my_Form_Principal_Load(object sender, EventArgs e)
        {

        }


        //MY METHODS_EVENTS_ACTIONS-CLIENTES- TAB1-PEDIDOS
        private void my_bt_Novo_tab1_Click(object sender, EventArgs e)
        {
            var orderApp = new myOrderAplication();
            my_txt_NumeroPedido_tab1.Text = orderApp.Method_APP_Select_NewId().ToString();
            my_gbx_ConsultaClient_tab1.Enabled = true;
            my_gbx_Observacoes_tab1.Enabled = true;
            my_bt_Buscar_consultacliente_tab1.Focus();
        }

        private void my_bt_Buscar_consultacliente_tab1_Click(object sender, EventArgs e)
        {
            //SET GRID FALSE COLLUMS AUTOMATIC
            this.my_DataGridView_Cliente_tab1.AutoGenerateColumns = false;
            //===================================================

            var cliApp = new myClientAplication();

            if (my_ck_PrimeiroNome_consultacliente_tab1.Checked==false && my_ck_Empresa_consultacliente_tab1.Checked == false)
            {
                my_DataGridView_Cliente_tab1.Enabled = true;
                my_DataGridView_Cliente_tab1.DataSource = cliApp.Method_APP_SelectAll();
                my_DataGridView_Cliente_tab1.ClearSelection();
                Method_UI_SetCountSelecRow_Client_tab1(cliApp.Method_APP_SelectAll().Count);
            }
            else if(my_ck_PrimeiroNome_consultacliente_tab1.Checked == true && my_ck_Empresa_consultacliente_tab1.Checked == false)
            {
                my_DataGridView_Cliente_tab1.Enabled = true;
                my_DataGridView_Cliente_tab1.DataSource = cliApp.Method_APP_SelectBy_Name(my_txt_PrimeiroNome_consultacliente_tab1.Text.ToString());
                my_DataGridView_Cliente_tab1.ClearSelection();
                Method_UI_SetCountSelecRow_Client_tab1(cliApp.Method_APP_SelectBy_Name(my_txt_PrimeiroNome_consultacliente_tab1.Text.ToString()).Count);
            }
            else if(my_ck_PrimeiroNome_consultacliente_tab1.Checked == false && my_ck_Empresa_consultacliente_tab1.Checked == true)
            {
                my_DataGridView_Cliente_tab1.Enabled = true;
                my_DataGridView_Cliente_tab1.DataSource = cliApp.Method_APP_SelectBy_Company(my_cbx_Empresa_consultacliente_tab1.SelectedItem.ToString());
                my_DataGridView_Cliente_tab1.ClearSelection();
                Method_UI_SetCountSelecRow_Client_tab1(cliApp.Method_APP_SelectBy_Company(my_cbx_Empresa_consultacliente_tab1.SelectedItem.ToString()).Count);
            }
            else if(my_ck_PrimeiroNome_consultacliente_tab1.Checked == true && my_ck_Empresa_consultacliente_tab1.Checked == true)
            {
                my_DataGridView_Cliente_tab1.Enabled = true;
                my_DataGridView_Cliente_tab1.DataSource = cliApp.Method_APP_SelectBy_NameAndCompany(my_txt_PrimeiroNome_consultacliente_tab1.Text.ToString(),my_cbx_Empresa_consultacliente_tab1.SelectedItem.ToString());
                my_DataGridView_Cliente_tab1.ClearSelection();
                Method_UI_SetCountSelecRow_Client_tab1(cliApp.Method_APP_SelectBy_NameAndCompany(my_txt_PrimeiroNome_consultacliente_tab1.Text.ToString(),my_txt_PrimeiroNome_consultacliente_tab1.Text.ToString()).Count);
            }
        }

        private void my_DataGridView_Cliente_tab1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            int countRow = my_DataGridView_Cliente_tab1.SelectedRows.Count;
            //myLblCountSelectRow1.Text = countRow.ToString();

            if (countRow>0)
            {
                my_bt_Carregar_consultacliente_tab1.Enabled = true;
            }
            else if (countRow == 0)
            {
                my_bt_Carregar_consultacliente_tab1.Enabled = false;
            }

        }
        
        private void my_bt_Carregar_consultacliente_tab1_Click(object sender, EventArgs e)
        {
            Method_UI_SetClientForOrder_Client_tab1();
            my_gbx_ConsultaClient_tab1.Enabled = false;
            //
            my_bt_Buscar_consultaprato_tab1.Focus();
            //
            my_bt_Cancelar_tab1.Enabled = true;
            //
            my_bt_Remover_selecionadocliente_tab1.Enabled = true;
        }

        private void my_bt_Limpar_consultacliente_tab1_Click(object sender, EventArgs e)
        {
            Method_UI_ClearGrid_Client_tab1();
            
        }

        private void my_ck_Empresa_consultacliente_tab1_CheckedChanged(object sender, EventArgs e)
        {
            if (my_ck_Empresa_consultacliente_tab1.Checked == true)
            {
                //ADIONAR COMBO
                Method_UI_SetComboCompany_Client_tab1(true);
                my_cbx_Empresa_consultacliente_tab1.Enabled = true;
                my_cbx_Empresa_consultacliente_tab1.Focus();
            }
            else
            {
                this.my_DataGridView_Cliente_tab1.AutoGenerateColumns = false;
                my_cbx_Empresa_consultacliente_tab1.DataSource = null;
                my_cbx_Empresa_consultacliente_tab1.Enabled = false;
                if (my_ck_PrimeiroNome_consultacliente_tab1.Checked==false)
                {
                    Method_UI_ClearGrid_Client_tab1();
                }
               
            }
        }

        private void my_ck_PrimeiroNome_consultacliente_tab1_CheckedChanged(object sender, EventArgs e)
        {
            if (my_ck_PrimeiroNome_consultacliente_tab1.Checked == true)
            {
                my_txt_PrimeiroNome_consultacliente_tab1.Enabled = true;
                my_txt_PrimeiroNome_consultacliente_tab1.Focus();
            }
            else
            {
                this.my_DataGridView_Cliente_tab1.AutoGenerateColumns = false;
                my_txt_PrimeiroNome_consultacliente_tab1.Text = null;
                my_txt_PrimeiroNome_consultacliente_tab1.Enabled = false;
                if (my_ck_Empresa_consultacliente_tab1.Checked == false)
                {
                    Method_UI_ClearGrid_Client_tab1();
                }
            }
        }


        //MY METHODS_EVENTS_ACTIONS-PRATOS-TAB1-PEDIDOS
        private void my_bt_Buscar_consultaprato_tab1_Click(object sender, EventArgs e)
        {
            //SET GRID FALSE AUTOMATIC GENERATE COLUMNS
            my_DataGridView_Prato_tab1.AutoGenerateColumns = false;
            //================================================
            var foodApp = new myFoodAplication();
            if(my_ck_Cod_consultaprato_tab1.Checked ==false && my_ck_NomePrato_consultaprato_tab1.Checked == false)
            {
                my_DataGridView_Prato_tab1.Enabled = true;
                my_DataGridView_Prato_tab1.DataSource = foodApp.Method_APP_SelectAll();
                my_DataGridView_Prato_tab1.ClearSelection();
                Method_UI_SetCountSelecRow_Food_tab1(foodApp.Method_APP_SelectAll().Count);
            }
            else if (my_ck_Cod_consultaprato_tab1.Checked == true && my_ck_NomePrato_consultaprato_tab1.Checked == false)
            {
                my_DataGridView_Prato_tab1.Enabled = true;
                my_DataGridView_Prato_tab1.DataSource = foodApp.Method_APP_SelectBy_Id(my_txt_Cod_consultaprato_tab1.Text.ToString());
                my_DataGridView_Prato_tab1.ClearSelection();
                Method_UI_SetCountSelecRow_Food_tab1(foodApp.Method_APP_SelectBy_Id(my_txt_Cod_consultaprato_tab1.Text.ToString()).Count);
            }
            else if(my_ck_Cod_consultaprato_tab1.Checked == false && my_ck_NomePrato_consultaprato_tab1.Checked == true)
            {
                my_DataGridView_Prato_tab1.Enabled = true;
                my_DataGridView_Prato_tab1.DataSource = foodApp.Method_APP_SelectBy_NameFood(my_txt_Prato_consultaprato_tab1.Text.ToString());
                my_DataGridView_Prato_tab1.ClearSelection();
                Method_UI_SetCountSelecRow_Food_tab1(foodApp.Method_APP_SelectBy_NameFood(my_txt_Prato_consultaprato_tab1.Text.ToString()).Count);
            }
        }

        private void my_ck_Cod_consultaprato_tab1_CheckedChanged(object sender, EventArgs e)
        {
            if (my_ck_Cod_consultaprato_tab1.Checked == true)
            {
                my_ck_NomePrato_consultaprato_tab1.Checked = false;
                
                //
               // Method_UI_SetComboJobTitle2(true);
                my_txt_Cod_consultaprato_tab1.Enabled = true;
                my_txt_Cod_consultaprato_tab1.Focus();
            }
            else
            {
                Method_UI_ClearGrid_Food_tab1();
                my_txt_Cod_consultaprato_tab1.Enabled = false;
                my_txt_Cod_consultaprato_tab1.Text = null;
            }

           }

        private void my_DataGridView_Prato_tab1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            
            int countRow = my_DataGridView_Prato_tab1.SelectedRows.Count;

            if (countRow > 0)
            {
                my_bt_Adicionar_Pedido_tab1.Enabled = true;
            }
            else if (countRow == 0)
            {
                my_bt_Adicionar_Pedido_tab1.Enabled = false;
            }
        }

        private void my_bt_Limpar_consultaprato_Click(object sender, EventArgs e)
        {
            Method_UI_ClearGrid_Food_tab1();
        }

        private void my_bt_Remove_pedido_tab1_Click(object sender, EventArgs e)
        {
            my_DataGridView_Pedido_tab1.Rows.RemoveAt(my_DataGridView_Pedido_tab1.CurrentRow.Index);
            //REFRESH CONTADOR DE LINHAS
            Method_UI_SetCountSelecRow_Order_tab1(my_DataGridView_Pedido_tab1.Rows.Count);
            //REFRESH SELECAO DE LINHAS
            my_DataGridView_Pedido_tab1.ClearSelection();
            my_bt_Remove_Pedido_tab1.Enabled = false;
            //CALC SUM PRICE FOR LABEL
            var orderApp = new myOrderAplication();
            my_lb_Custo_Pedido_tab1.Text = orderApp.Method_APP_CalcSumPrice(Method_UI_CreateListId_Food()).ToString();

        }

        private void my_bt_Remover_clienteselecionado_tab1_Click(object sender, EventArgs e)
        {
            my_gbx_ConsultaClient_tab1.Enabled = true;
            //
            my_txt_Cod_selecionadocliente_tab1.Text = null;
            my_txt_PrimeiroNome_selecionadocliente_tab1.Text = null;
            my_txt_UltimoNome_selecionadocliente_tab1.Text = null;
            my_txt_Empresa_selecionadocliente_tab1.Text = null;
            //
            my_gbx_ClienteSelecionado_tab1.Enabled = false;
            my_gbx_ConsultaPrato_tab1.Enabled = false;
            my_gbx_Pedido_tab1.Enabled = false;
            //
            my_bt_Cancelar_tab1.Enabled = false;
            //
            my_bt_Remover_selecionadocliente_tab1.Enabled = false;
            //
            my_bt_Buscar_consultacliente_tab1.Focus();
        }

        private void my_ck_Prato_ConsultaPrato_tab1_CheckedChanged(object sender, EventArgs e)
        {
            if (my_ck_NomePrato_consultaprato_tab1.Checked == true)
            {
                my_ck_Cod_consultaprato_tab1.Checked = false;
                //
                my_txt_Prato_consultaprato_tab1.Enabled = true;
                my_txt_Prato_consultaprato_tab1.Focus();
            }
            else
            {
                Method_UI_ClearGrid_Food_tab1();
                my_txt_Prato_consultaprato_tab1.Enabled = false;
                my_txt_Prato_consultaprato_tab1.Text = null;
            }
        }

        private void my_bt_Adicionar_Pedido_tb1_Click(object sender, EventArgs e)
        {
            Method_UI_AddForListOrder_Food();
            Method_UI_SetCountSelecRow_Order_tab1(my_DataGridView_Pedido_tab1.Rows.Count);
            //REFRESH SELECAO GRID
            my_DataGridView_Prato_tab1.ClearSelection();
            my_DataGridView_Pedido_tab1.ClearSelection();
            my_bt_Adicionar_Pedido_tab1.Enabled = false;
            //CALC SUM PRICE FOR LABEL
            var orderApp = new myOrderAplication();
            my_lb_Custo_Pedido_tab1.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:#,###.##}", orderApp.Method_APP_CalcSumPrice(Method_UI_CreateListId_Food()).ToString());

        }

        private void my_DataGridView_Pedido_tab1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            int countRow = my_DataGridView_Pedido_tab1.SelectedRows.Count;

            if (countRow > 0)
            {
                my_bt_Remove_Pedido_tab1.Enabled = true;
            }
            else if (countRow == 0)
            {
                my_bt_Remove_Pedido_tab1.Enabled = false;
            }
            
        }

        private void my_bt_Finalizar_Pedido_tab1_Click(object sender, EventArgs e)
        {
            Method_UI_Finish_Order();
        }



        //MY METHODS_EVENTS_ACTIONS-PRATOS-TAB2-PRATOS
        private void my_bt_Buscar_tab2_Click(object sender, EventArgs e)
        {
            //SET GRID FALSE AUTOMATIC GENERATE COLUMNS
            my_DataGridView_Prato_tab1.AutoGenerateColumns = false;
            //================================================
            var foodApp = new myFoodAplication();
            if (my_ck_Cod_consultaprato_tab2.Checked == false && my_ck_NomePrato_consultaprato_tab2.Checked == false && my_ck_Porcao_consultaprato_tab2.Checked==false)
            {
                my_DataGridView_Prato_tab2.Enabled = true;
                my_DataGridView_Prato_tab2.DataSource = foodApp.Method_APP_SelectAll();
                my_DataGridView_Prato_tab2.ClearSelection();
                Method_UI_SetCountSelecRow_Food_tab2(foodApp.Method_APP_SelectAll().Count);
            }
            else if (my_ck_Cod_consultaprato_tab2.Checked == true && my_ck_NomePrato_consultaprato_tab2.Checked == false && my_ck_Porcao_consultaprato_tab2.Checked == false)
            {
                my_DataGridView_Prato_tab1.Enabled = true;
                my_DataGridView_Prato_tab2.DataSource = foodApp.Method_APP_SelectBy_Id(my_txt_Cod_consultaprato_tab2.Text.ToString());
                my_DataGridView_Prato_tab1.ClearSelection();
                Method_UI_SetCountSelecRow_Food_tab2(foodApp.Method_APP_SelectBy_Id(my_txt_Cod_consultaprato_tab2.Text.ToString()).Count);
            }
            else if (my_ck_Cod_consultaprato_tab2.Checked == false && my_ck_NomePrato_consultaprato_tab2.Checked == true && my_ck_Porcao_consultaprato_tab2.Checked == false)
            {
                my_DataGridView_Prato_tab2.Enabled = true;
                my_DataGridView_Prato_tab2.DataSource = foodApp.Method_APP_SelectBy_NameFood(my_txt_NomePrato_consultaprato_tab2.Text.ToString());
                my_DataGridView_Prato_tab2.ClearSelection();
                Method_UI_SetCountSelecRow_Food_tab2(foodApp.Method_APP_SelectBy_NameFood(my_txt_NomePrato_consultaprato_tab2.Text.ToString()).Count);
            }
            else if (my_ck_Cod_consultaprato_tab2.Checked == false && my_ck_NomePrato_consultaprato_tab2.Checked == false && my_ck_Porcao_consultaprato_tab2.Checked == true)
            {
                my_DataGridView_Prato_tab2.Enabled = true;
                my_DataGridView_Prato_tab2.DataSource = foodApp.Method_APP_SelectBy_Portion(my_cbx_Porcao_consulta_tab2.SelectedItem.ToString());
                my_DataGridView_Prato_tab2.ClearSelection();
                Method_UI_SetCountSelecRow_Food_tab2(foodApp.Method_APP_SelectBy_Portion(my_cbx_Porcao_consulta_tab2.SelectedItem.ToString()).Count);
            }
        }
        
        private void my_tab_Principal_SelectedIndexChanged(object sender, EventArgs e)
        {
         // MessageBox.Show("You are in the TabControl.SelectedIndexChanged event.");
            //if (my_tab_Principal.SelectedIndex==0)
            //{
            //    MessageBox.Show("Pagina Pedidos");
            //}
            //else if (my_tab_Principal.SelectedIndex == 1)
            //{
            //    MessageBox.Show("Pagina Pratos");
            //}
            //else if (my_tab_Principal.SelectedIndex == 2)
            //{
            //    MessageBox.Show("Pagina Clientes");
            //}
            //else if (my_tab_Principal.SelectedIndex == 3)
            //{
            //    MessageBox.Show("Pagina Historico");
            //}
            //else if (my_tab_Principal.SelectedIndex == 4)
            //{
            //    MessageBox.Show("Pagina Relatorios");
            //}
        }

        private void my_bt_Novo_tab2_Click(object sender, EventArgs e)
        {
            var foodApp = new myFoodAplication();
            my_txt_Cod_novo_tab2.Text = foodApp.Method_APP_Select_NewId().ToString();
            //HABILITA CAMPOS
            my_txt_NomePrato_novo_tab2.Enabled = true;
            my_txt_Preco_novo_tab2.Text = null;
            my_txt_NomePrato_novo_tab2.Focus();
            my_cbx_Porcao_novo_tab2.Enabled = true;
            my_cbx_Porcao_novo_tab2.SelectedIndex = 0;
            my_txt_Preco_novo_tab2.Enabled = true;
            my_txt_Preco_novo_tab2.Text = null;
            //
            my_bt_Salvar_tab2.Enabled = true;
        }

        private void my_ck_Cod_consulta_tab2_CheckedChanged(object sender, EventArgs e)
        {
            if (my_ck_Cod_consultaprato_tab2.Checked==true)
            {
                my_txt_Cod_consultaprato_tab2.Enabled = true;
                my_txt_Cod_consultaprato_tab2.Focus();
            }
            else if (my_ck_Cod_consultaprato_tab2.Checked==false)
            {
                my_txt_Cod_consultaprato_tab2.Text = null;
                my_txt_Cod_consultaprato_tab2.Enabled = false;
            }
        }

        private void my_ck_NomePrato_consulta_tab2_CheckedChanged(object sender, EventArgs e)
        {
            if (my_ck_NomePrato_consultaprato_tab2.Checked == true)
            {
                my_txt_NomePrato_consultaprato_tab2.Enabled = true;
                my_txt_NomePrato_consultaprato_tab2.Focus();
            }
            else if (my_ck_Cod_consultaprato_tab2.Checked == false)
            {
                my_txt_NomePrato_consultaprato_tab2.Text = null;
                my_txt_NomePrato_consultaprato_tab2.Enabled = false;
                Method_UI_ClearGrid_Food_tab2();
            }
        }

        private void my_ck_Porcao_consulta_tab2_CheckedChanged(object sender, EventArgs e)
        {
            if (my_ck_Porcao_consultaprato_tab2.Checked == true)
            {
                my_cbx_Porcao_consulta_tab2.Enabled = true;
                my_cbx_Porcao_consulta_tab2.SelectedIndex = 0;
                my_cbx_Porcao_consulta_tab2.Focus();
            }
            else if (my_ck_Cod_consultaprato_tab2.Checked == false)
            {
                my_cbx_Porcao_consulta_tab2.SelectedIndex = -1;
                my_cbx_Porcao_consulta_tab2.Enabled = false;
                Method_UI_ClearGrid_Food_tab2();

            }
        }

        private void my_bt_Limpar_tab2_Click(object sender, EventArgs e)
        {
            Method_UI_ClearGrid_Food_tab2();
        }

        private void my_DataGridView_Prato_tab2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            int countRow = my_DataGridView_Prato_tab2.SelectedRows.Count;

            if (countRow > 0)
            {
                my_bt_Editar_tab2.Enabled = true;
                my_bt_Deletar_tab2.Enabled = true;
            }
            else if (countRow == 0)
            {
                my_bt_Editar_tab2.Enabled = false;
                my_bt_Deletar_tab2.Enabled = false;
            }
        }

        private void my_bt_Editar_tab2_Click(object sender, EventArgs e)
        {
            Method_UI_SetFoodFor_Edit_tab2();
        }

        private void my_bt_Salvar_tab2_Click(object sender, EventArgs e)
        {
            Method_UI_Save_Food();
        }

        private void my_bt_Deletar_tab2_Click(object sender, EventArgs e)
        {
            Method_UI_Delete_Food();
        }




        //MY METHODS_EVENTS_ACTIONS-CLIENTES-TAB3-CLIENTES
        private void my_bt_Buscar_tab3_Click(object sender, EventArgs e)
        {
            //SET GRID FALSE COLLUMS AUTOMATIC
            this.my_DataGridView_Cliente_tab3.AutoGenerateColumns = false;
            //===================================================

            var cliApp = new myClientAplication();
            if (my_ck_Cod_consultacliente_tab3.Checked==false && my_ck_PrimeiroNome_consultacliente_tab3.Checked == false && my_ck_Empresa_consultacliente_tab3.Checked == false)
            {
                my_DataGridView_Cliente_tab3.Enabled = true;
                my_DataGridView_Cliente_tab3.DataSource = cliApp.Method_APP_SelectAll();
                my_DataGridView_Cliente_tab3.ClearSelection();
                Method_UI_SetCountSelecRow_Client_tab3(cliApp.Method_APP_SelectAll().Count);
            }
            else if (my_ck_Cod_consultacliente_tab3.Checked == false && my_ck_PrimeiroNome_consultacliente_tab3.Checked == true && my_ck_Empresa_consultacliente_tab3.Checked == false)
            {
                my_DataGridView_Cliente_tab3.Enabled = true;
                my_DataGridView_Cliente_tab3.DataSource = cliApp.Method_APP_SelectBy_Name(my_txt_PrimeiroNome_consultacliente_tab3.Text.ToString());
                my_DataGridView_Cliente_tab3.ClearSelection();
                Method_UI_SetCountSelecRow_Client_tab3(cliApp.Method_APP_SelectBy_Name(my_txt_PrimeiroNome_consultacliente_tab3.Text.ToString()).Count);
            }
            else if (my_ck_Cod_consultacliente_tab3.Checked == false && my_ck_PrimeiroNome_consultacliente_tab3.Checked == false && my_ck_Empresa_consultacliente_tab3.Checked == true)
            {
                my_DataGridView_Cliente_tab3.Enabled = true;
                my_DataGridView_Cliente_tab3.DataSource = cliApp.Method_APP_SelectBy_Company(my_cbx_Empresa_consultacliente_tab3.SelectedItem.ToString());
                my_DataGridView_Cliente_tab3.ClearSelection();
                Method_UI_SetCountSelecRow_Client_tab3(cliApp.Method_APP_SelectBy_Company(my_cbx_Empresa_consultacliente_tab3.Text.ToString()).Count);
            }
            else if (my_ck_Cod_consultacliente_tab3.Checked == true && my_ck_PrimeiroNome_consultacliente_tab3.Checked == false && my_ck_Empresa_consultacliente_tab3.Checked == false)
            {
                my_DataGridView_Cliente_tab3.Enabled = true;
                my_DataGridView_Cliente_tab3.DataSource = cliApp.Method_APP_SelectBy_Id(Convert.ToInt32(my_txt_Cod_consultacliente_tab3.Text.ToString()));
                my_DataGridView_Cliente_tab3.ClearSelection();
                Method_UI_SetCountSelecRow_Client_tab3(cliApp.Method_APP_SelectBy_Id(Convert.ToInt32(my_txt_Cod_consultacliente_tab3.Text.ToString())).Count);
            }
        }

        private void my_ck_Cod_consultacliente_tab3_CheckedChanged(object sender, EventArgs e)
        {
            if (my_ck_Cod_consultacliente_tab3.Checked == true)
            {
                my_txt_Cod_consultacliente_tab3.Enabled = true;
                my_txt_Cod_consultacliente_tab3.Focus();
            }
            else if (my_ck_Cod_consultacliente_tab3.Checked == false)
            {
                my_txt_Cod_consultacliente_tab3.Text = null;
                my_txt_Cod_consultacliente_tab3.Enabled = false;
                Method_UI_ClearGrid_Cliente_tab3();
            }
        }

        private void my_ck_PrimeiroNome_consultacliente_tab3_CheckedChanged(object sender, EventArgs e)
        {
            if (my_ck_PrimeiroNome_consultacliente_tab3.Checked == true)
            {
                my_txt_PrimeiroNome_consultacliente_tab3.Enabled = true;
                my_txt_PrimeiroNome_consultacliente_tab3.Focus();
            }
            else if (my_ck_Cod_consultacliente_tab3.Checked == false)
            {
                my_txt_PrimeiroNome_consultacliente_tab3.Text = null;
                my_txt_PrimeiroNome_consultacliente_tab3.Enabled = false;
                Method_UI_ClearGrid_Cliente_tab3();
            }
        }

        private void my_ck_Empresa_consultacliente_tab3_CheckedChanged(object sender, EventArgs e)
        {
            if (my_ck_Empresa_consultacliente_tab3.Checked == true)
            {
                Method_UI_SetComboCompany_Client_tab3(true);
                my_cbx_Empresa_consultacliente_tab3.Enabled = true;
                my_cbx_Empresa_consultacliente_tab3.Focus();
            }
            else if (my_ck_Empresa_consultacliente_tab3.Checked == false)
            {
                my_cbx_Empresa_consultacliente_tab3.DataSource = null;
                my_cbx_Empresa_consultacliente_tab3.Text = null;
                my_cbx_Empresa_consultacliente_tab3.Enabled = false;
                Method_UI_ClearGrid_Cliente_tab3();
            }
        }

        private void my_bt_Limpar_tab3_Click(object sender, EventArgs e)
        {
            Method_UI_ClearGrid_Cliente_tab3();
        }

        private void my_DataGridView_Cliente_tab3_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            int countRow = my_DataGridView_Cliente_tab3.SelectedRows.Count;

            if (countRow > 0)
            {
                my_bt_Editar_tab3.Enabled = true;
                my_bt_Deletar_tab3.Enabled = true;
            }
            else if (countRow == 0)
            {
                my_bt_Editar_tab3.Enabled = false;
                my_bt_Deletar_tab3.Enabled = false;
            }
        }

        private void my_bt_Editar_tab3_Click(object sender, EventArgs e)
        {
            Method_UI_SetClientFor_Edit_tab3();
        }

        private void my_bt_Novo_tab3_Click(object sender, EventArgs e)
        {
            var clientApp = new myClientAplication();
            my_txt_Cod_novo_tab3.Text = clientApp.Method_APP_Select_NewId().ToString();
            //HABILITA CAMPOS
            my_txt_PrimeiroNome_novo_tab3.Enabled = true;
            my_txt_PrimeiroNome_novo_tab3.Text = null;
            my_txt_PrimeiroNome_novo_tab3.Focus();
            my_txt_UltimoNome_novo_tab3.Enabled = true;
            my_txt_UltimoNome_novo_tab3.Text = null;
            my_cbx_Sexo_novo_tab3.Enabled = true;
            my_cbx_Sexo_novo_tab3.SelectedIndex = 0;
            my_txt_Empresa_novo_tab3.Enabled = true;
            my_txt_Empresa_novo_tab3.Text = null;
            //
            my_bt_Salvar_tab3.Enabled = true;
        }

        private void my_bt_Salvar_tab3_Click(object sender, EventArgs e)
        {
            Method_UI_Save_Cliente();
        }

        private void my_bt_Deletar_tab3_Click(object sender, EventArgs e)
        {
            Method_UI_Delete_Client();
        }

        private void my_bt_Cancelar_tab1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sim ou Não", "Deseja cancelar esse pedido?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                Method_UI_Cancel_Order();
            }
        }





        //MY METHODS_EVENTS_ACTIONS-PEDIDOS-TAB4-HISTORICO DE PEDIDOS
        private void my_bt_Buscar_consultapedido_tab4_Click(object sender, EventArgs e)
        {
            my_DataGridView_Pedidos_tab4.AutoGenerateColumns = false;
            var orderApp = new myOrderAplication();
            my_DataGridView_Pedidos_tab4.Enabled = true;
            my_DataGridView_Pedidos_tab4.DataSource = orderApp.Method_APP_SelectAll();
            //my_DataGridView_Pedidos_tab4.ClearSelection();
            Method_UI_SetCountSelecRow_Client_tab4(orderApp.Method_APP_SelectAll().Count);

        }


        private void my_DataGridView_Pedidos_tab4_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            int countRow = my_DataGridView_Pedidos_tab4.SelectedRows.Count;

            if (countRow > 0)
            {
                my_DataGridView_ListaPedidos_tab4.AutoGenerateColumns = false;
                var listOrderApp = new myListOrderAplication();
                my_DataGridView_ListaPedidos_tab4.DataSource = listOrderApp.Method_APP_SelectBy_Id(Convert.ToInt32(my_DataGridView_Pedidos_tab4.CurrentRow.Cells[0].Value.ToString()));
            }
            else if (countRow == 0)
            {
               
            }
        }

    }
}