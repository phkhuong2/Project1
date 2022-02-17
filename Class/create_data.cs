using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace luan_van1
{
    class create_data
    {
        public void All_delete_data(string fileName)
        {
            XDocument emp1 = XDocument.Load(fileName);
            emp1.Root.RemoveAll();
            emp1.Save(fileName);
        }
        public void Gear_create_data(string fileName,int index)
        {
            //string fileName = "dataC1.xml";
            XDocument emp1 = XDocument.Load(fileName);//.Descendants("dataC1").FirstOrDefault();
                                                          //XDocument emp1 = new XDocument();
            #region
            emp1.Root.Add(new XElement("dataC" + index.ToString(),
                new XElement("d_VL1", 0),
                new XElement("d_VL2", 0),
                new XElement("d_NhietLuyen1", 0),
                new XElement("d_NhietLuyen2", 0),
                new XElement("d_HB_1", 0),
                new XElement("d_HB_2", 0),
                new XElement("d_sigma_b1", 0),
                new XElement("d_sigma_b2", 0),
                new XElement("d_sigma_ch1", 0),
                new XElement("d_sigma_ch2", 0),
                new XElement("d_K_FC", 0),
                new XElement("d_K_FC_cond", 0),
                new XElement("d_sigma_Hlim1", 0),
                new XElement("d_sigma_Hlim2", 0),
                new XElement("d_sigma_Flim1", 0),
                new XElement("d_sigma_Flim2", 0),
                new XElement("d_cond1", 0),
                new XElement("d_N_HO1", 0),
                new XElement("d_N_HO2", 0),
                new XElement("d_N_FO1", 0),
                new XElement("d_N_FO2", 0),
                new XElement("d_N_HE1", 0),
                new XElement("d_N_HE2", 0),
                new XElement("d_N_FE1", 0),
                new XElement("d_N_FE2", 0),
                new XElement("d_N_HO1", 0),
                new XElement("d_N_HO1", 0),
                new XElement("d_K_HL1", 0),
                new XElement("d_K_HL2", 0),
                new XElement("d_K_FL1", 0),
                new XElement("d_K_FL2", 0),
                new XElement("d_Sigma_H1_bound", 0),
                new XElement("d_Sigma_H2_bound", 0),
                new XElement("d_Sigma_H_average_bound", 0),
                new XElement("d_Sigma_F1_bound", 0),
                new XElement("d_Sigma_F2_bound", 0),
                new XElement("d_Sigma_H1max_bound", 0),
                new XElement("d_Sigma_H2max_bound", 0),
                new XElement("d_Sigma_F1max_bound", 0),
                new XElement("d_Sigma_F2max_bound", 0),

                new XElement("d_K_a", 0),
                new XElement("d_K_d", 0),
                new XElement("d_psi_ba", 0),
                new XElement("d_in_external", 0),
                new XElement("d_cond2", 0),
                new XElement("d_cond3", 0),
                new XElement("d_psi_bd", 0),
                new XElement("d_K_H_beta", 0),
                new XElement("d_x1", 0),
                new XElement("d_x2", 0),
                new XElement("d_k_y", 0),
                new XElement("d_beta_angle_pre", 0),
                new XElement("d_alpha_angle", 0),
                new XElement("d_pre_a_w", 0),
                new XElement("d_pre_a_w_modify", 0),
                new XElement("d_a_w", 0),
                new XElement("d_a_w_modify", 0),
                new XElement("d_a_w_dc", 0),
                new XElement("d_a_w_dc_modify", 0),
                new XElement("d_m", 0),
                new XElement("d_m_modify", 0),
                new XElement("d_z_1", 0),
                new XElement("d_z_2", 0),
                new XElement("d_beta_angle", 0),
                new XElement("d_k_x", 0),
                new XElement("d_delta_y", 0),

                new XElement("d_ViTriAnKhop", 0),

                new XElement("d_D_1", 0),
                new XElement("d_D_2", 0),
                new XElement("d_D_w1", 0),
                new XElement("d_D_w2", 0),
                new XElement("d_D_a1", 0),
                new XElement("d_D_a2", 0),
                new XElement("d_D_f1", 0),
                new XElement("d_D_f2", 0),
                new XElement("d_D_b1", 0),
                new XElement("d_D_b2", 0),
                new XElement("d_alpha_t_angle", 0),
                new XElement("d_alpha_tw_angle", 0),

                new XElement("K_R_pre", 0),
                new XElement("R_e_pre", 0),
                new XElement("D_e1_pre", 0),
                new XElement("Z1", 0),
                new XElement("Z2", 0),
                new XElement("D_m1_pre", 0),
                new XElement("M_tm", 0),
                new XElement("M_te", 0),
                new XElement("M_tm_new1", 0),
                new XElement("D_m1_new1", 0),
                new XElement("R_e", 0),
                new XElement("B", 0),
                new XElement("R_m", 0),
                new XElement("D_e1", 0),
                new XElement("D_e2", 0),
                new XElement("Bevel_angle1", 0),
                new XElement("Bevel_angle2", 0),
                new XElement("H_e", 0),
                new XElement("H_ae1", 0),
                new XElement("H_ae2", 0),
                new XElement("H_fe1", 0),
                new XElement("H_fe2", 0),
                new XElement("D_ae1", 0),
                new XElement("D_ae2", 0),
                new XElement("S_e1", 0),
                new XElement("S_e2", 0),
                new XElement("Pin_f1_angle", 0),
                new XElement("Pin_f2_angle", 0),
                new XElement("Bevel_a1_angle", 0),
                new XElement("Bevel_a2_angle", 0),
                new XElement("Bevel_f1_angle", 0),
                new XElement("Bevel_f2_angle", 0),
                new XElement("D_m1", 0),
                new XElement("D_m2", 0),
                new XElement("B1", 0),
                new XElement("B2", 0),
                new XElement("M_tm", 0),
                new XElement("M_nm", 0),
                new XElement("d_K_be", 0),
                new XElement("d_z1p", 0),
                new XElement("d_beta_m_angle", 0),
                new XElement("d_x_n1", 0),
                new XElement("d_x_t1", 0),
                new XElement("d_alpha_n_angle", 0),
                new XElement("d_M_te_new1", 0),

                new XElement("d_Beta_b_angle", 0),
                new XElement("d_Z_H", 0),
                new XElement("d_B_w", 0),
                new XElement("d_Epsilon_alpha", 0),
                new XElement("d_Epsilon_beta", 0),
                new XElement("d_Z_epsilon", 0),
                new XElement("d_Sigma_H", 0),
                new XElement("d_K_H", 0),
                new XElement("d_V", 0),
                new XElement("d_V_H", 0),
                new XElement("d_K_H_nu", 0),
                new XElement("d_K_H", 0),
                new XElement("d_Z_M", 0),
                new XElement("d_K_H_alpha", 0),
                new XElement("d_delta_H", 0),
                new XElement("d_g_o", 0),

                new XElement("d_Y_beta", 0),
                new XElement("d_Y_epsilon", 0),
                new XElement("d_Z_v1", 0),
                new XElement("d_Z_v2", 0),
                new XElement("d_K_F", 0),
                new XElement("d_Sigma_F1", 0),
                new XElement("d_Sigma_F2", 0),
                new XElement("d_V_F", 0),
                new XElement("d_K_F_nu", 0),
                new XElement("d_Delta_F", 0),
                new XElement("d_K_qt", 0),
                new XElement("d_Sigma_Hmax", 0),
                new XElement("d_Sigma_F1max", 0),
                new XElement("d_Sigma_F2max", 0),
                new XElement("d_Y_F1", 0),
                new XElement("d_Y_F2", 0),
                new XElement("d_K_F_alpha", 0),
                new XElement("d_K_F_beta", 0),
                new XElement("d_delta_F", 0),
                new XElement("d_Ti_Tmax_engine", 0),
                new XElement("d_CapChinhXac", 0)
                ));
            #endregion
            
            //emp1.Root.Element("dataC" + index.ToString()).Remove();
            //emp1.Root.RemoveAll();
            //Console.WriteLine(emp1.Root.Element("dataC2").Element("d_VL1").Value);
            emp1.Save(fileName);
        }
        public void Perform_create_data(string fileName, int index)
        {
            XDocument emp1 = XDocument.Load(fileName);
            #region
            emp1.Root.Add(new XElement("dataC" + index.ToString(),
                new XElement("stt", 0),
                new XElement("Name", 0),
                new XElement("n_bound", 0),
                new XElement("n", 0)
                ));
            #endregion
            emp1.Save(fileName);
        }
        public void delete_data(string fileName, int index)
        {
            XDocument emp1 = XDocument.Load(fileName);
            emp1.Root.Element("dataC" + index.ToString()).Remove();
            emp1.Save(fileName);
        }
        public void rename_data(string fileName, int index, string name)
        {
            XDocument emp1 = XDocument.Load(fileName);
            emp1.Root.Element("dataC" + index.ToString()).Name = name;
            emp1.Save(fileName);
        }

        
    }
}
