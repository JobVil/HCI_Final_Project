string connString = "Server=HCI_Proj;Database=master;User=sa;Password=password123!;";
string sql = "spGrabAllWithTagAndLights";

using(SqlConnection conn = new SqlConnection(connString))
{
    try
    {
        using(SqlDataAdapter da = new SqlDataAdapter())
        {
            da.SelectCommand = new SqlCommand(sql, conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            // Remove these two lines if your stored procedure doesn't have parameters
            da.SelectCommand.Parameters.AddWithValue("@FilterTag", "wood");
            da.SelectCommand.Parameters.AddWithValue("@LightNum", "3");

            DataSet ds = new DataSet();
            da.Fill(ds, "result_name");

            DataTable dt = ds.Tables["result_name"];

            foreach (DataRow row in dt.Rows) {
                //manipulate your data
            }
        }
    }
    catch(SQLException ex)
    {
        Console.WriteLine("SQL Error: " + ex.Message);
    }
    catch(Exception e)
    {
        Console.WriteLine("Error: " + e.Message);
    }
}
