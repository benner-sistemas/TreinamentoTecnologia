def InitializeRow(entity, row):
    row.GetCellByName("STATUS").Tooltip = row.GetCellByName("STATUS").Text
    row.GetCellByName("STATUS").Text = ""
    if (entity["STATUS"].GetInt32() == 1):
        row.GetCellByName("STATUS").FontIcon = "fa fa-clock-o"
        row.GetCellByName("STATUS").TextColor = "#c49f47"
    elif (entity["STATUS"].GetInt32() == 2):
        row.GetCellByName("STATUS").FontIcon = "fa fa-thumbs-up"
        row.GetCellByName("STATUS").TextColor = "#3598dc"
    elif (entity["STATUS"].GetInt32() == 3):
        row.GetCellByName("STATUS").FontIcon = "fa fa-thumbs-down"
        row.GetCellByName("STATUS").TextColor = "#cb5a5e"
    elif (entity["STATUS"].GetInt32() == 4):
        row.GetCellByName("STATUS").FontIcon = "fa fa-mail-reply-all"
        row.GetCellByName("STATUS").TextColor = "#95a5a6"
    elif (entity["STATUS"].GetInt32() == 5):
        row.GetCellByName("STATUS").FontIcon = "fa fa-dollar"
        row.GetCellByName("STATUS").TextColor = "#1ba39c"
