def InitializeRow(entity, row):
    if (entity == None or row == None): return
    ativo = entity["ATIVO"].GetBoolean()
    if (ativo == None): ativo = False
    row.GetCustomCommand("CMD_Ativar").Enabled = not ativo
    row.GetCustomCommand("CMD_Desativar").Enabled = ativo
    row.GetCellByName("ATIVO").Text = ""
    row.GetCellByName("ATIVO").TextColor = "#00ff00" if (ativo) else "#ff0000"
    row.GetCellByName("ATIVO").FontIcon = "fa fa-lock" if (ativo) else "fa fa-unlock"
