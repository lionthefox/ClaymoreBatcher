namespace ClaymoreBatcher
{
  partial class ImportView
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.listView1 = new System.Windows.Forms.ListView();
      this.Parameter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Delete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SuspendLayout();
      // 
      // listView1
      // 
      this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Parameter,
            this.Value,
            this.Delete});
      this.listView1.GridLines = true;
      this.listView1.Location = new System.Drawing.Point(16, 128);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(771, 215);
      this.listView1.TabIndex = 3;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      // 
      // Parameter
      // 
      this.Parameter.Text = "Parameter";
      this.Parameter.Width = 582;
      // 
      // Value
      // 
      this.Value.Text = "Value";
      this.Value.Width = 127;
      // 
      // Delete
      // 
      this.Delete.Text = "";
      // 
      // ImportView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.listView1);
      this.Name = "ImportView";
      this.Text = "ImportView";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.ColumnHeader Parameter;
    private System.Windows.Forms.ColumnHeader Value;
    private System.Windows.Forms.ColumnHeader Delete;
  }
}