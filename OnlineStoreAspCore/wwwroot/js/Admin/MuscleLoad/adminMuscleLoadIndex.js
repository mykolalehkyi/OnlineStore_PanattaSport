class AdminMuscleLoadIndexPageController {
    constructor() {
        this.datatableId = "muscleLoadTable";
        this.createNewButtonId = "createNew";
        $(document).ready(() => this.init());
    }
    init() {
        this.initDataTable();
        this.initDataTableOnChange();
        this.initButtons();
    }
    initButtons() {
        $('#createNew').click(function () {
            let row = '<tr>';
            row += `<td><button type="button"  name="insertRow" id="insertRowButton" class="btn btn-success btn-xs">Insert</button></td>`;
            row += `<td contenteditable id="insertMuscleName"></td>`;
            row += `<td><div class="form-check"><input type="checkbox" class="form-check-input" id="insertCheckboxDisabled" checked><label for="insertCheckboxDisabled" class="form-check-label"> Disabled</label></div></td>`;
            row += '</tr>';
            $('#muscleLoadTable').prepend(row);
        });
        $(document).on('click', '#insertRowButton', function () {
            let muscleName = $('#insertMuscleName').text();
            let disabled = $('#insertCheckboxDisabled').is(':checked');
            $.ajax({
                url: "MuscleLoad/Create",
                method: "POST",
                data: { muscleName: muscleName, disabled: disabled },
                success: function (dataResponse) {
                    if (dataResponse.success) {
                        alert(dataResponse.message);
                        adminMuscleLoadIndexPageController.refreshDataTable();
                    }
                }
            });
        });
    }
    initDataTableOnChange() {
        $(document).on('blur', '.update', function () {
            let id = $(this).data("id");
            let column_name = $(this).data("column");
            let value = $(this).text();
            let muscleName = $("div[data-id=" + id + "][data-column=muscleName]").text();
            adminMuscleLoadIndexPageController.updateData(id, column_name, value, { muscleLoadId: id, muscleName: muscleName });
        });
    }
    initDataTable() {
        this.datatable = $("#" + this.datatableId).DataTable({
            "ajax": {
                "url": "MuscleLoad/GetList",
                "type": "GET",
                "dataType": "json",
            },
            "columns": [
                {
                    "data": "muscleLoadId",
                    "render": function (data, type, row) {
                        return `<div class="update" data-id="${row.muscleLoadId}" data-column="muscleLoadId">${row.muscleLoadId}</div>`;
                    }
                },
                {
                    "data": "muscleName",
                    "render": function (data, type, row) {
                        return `<div contenteditable class="update" data-id="${row.muscleLoadId}" data-column="muscleName">${row.muscleName}</div>`;
                    }
                },
                {
                    "data": "disabled",
                    "render": function (data, type, row) {
                        if (data == false) {
                            return `<button class="btn btn-danger" onclick="adminMuscleLoadIndexPageController.deactivateProduct('MuscleLoad/DeactivateItem?id=${row.muscleLoadId}')" >Deactivate</button>`;
                        }
                        else {
                            return `<button class="btn btn-success" onclick="adminMuscleLoadIndexPageController.activateProduct('MuscleLoad/ActivateItem?id=${row.muscleLoadId}')" >Activate</button>`;
                        }
                    }
                }
            ]
        });
    }
    updateData(id, column_name, value, dataRequest) {
        $.ajax({
            url: "MuscleLoad/Edit/" + id,
            method: "POST",
            data: dataRequest,
            success: function (dataResponse) {
                if (dataResponse.success) {
                    alert(dataResponse.message);
                }
            }
        });
    }
    populateDataTable(dataToTable) {
        this.datatable = $("#" + this.datatableId).DataTable();
        this.datatable.clear().draw();
        this.datatable.rows.add(dataToTable.data); // Add new data
        this.datatable.columns.adjust().draw(); // Redraw the DataTable
    }
    deactivateProduct(url) {
        $.ajax({
            type: "PUT",
            url: url,
            success: function (dataResponse) {
                if (dataResponse.success) {
                    alert(dataResponse.message);
                    adminMuscleLoadIndexPageController.refreshDataTable();
                }
                else {
                    alert(dataResponse.message);
                }
            }
        });
    }
    activateProduct(url) {
        $.ajax({
            type: "PUT",
            url: url,
            success: function (dataResponse) {
                if (dataResponse.success) {
                    alert(dataResponse.message);
                    adminMuscleLoadIndexPageController.refreshDataTable();
                }
                else {
                    alert(dataResponse.message);
                }
            }
        });
    }
    refreshDataTable() {
        let datatable = $("#muscleLoadTable").DataTable();
        datatable.ajax.reload();
    }
}
let adminMuscleLoadIndexPageController = new AdminMuscleLoadIndexPageController();
//# sourceMappingURL=adminMuscleLoadIndex.js.map