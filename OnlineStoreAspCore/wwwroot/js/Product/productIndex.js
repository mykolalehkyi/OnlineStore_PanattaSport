class ProductIndexPageController {
    constructor() {
        $(document).ready(() => this.init());
    }
    init() {
        this.initDataTable();
    }
    initDataTable() {
        this.datatable = $("#productTable");
        $("#productTable").DataTable({
            "ajax": {
                "url": "/Product/GetList",
                "type": "GET",
                "dataType": "json",
                "data": this.tableData
            },
            "columns": [
                { "data": "productId" },
                { "data": "productName" },
                { "data": "width" },
                { "data": "length" },
                { "data": "height" },
                { "data": "weight" },
                { "data": "standardLoad" },
                { "data": "optionalLoad" },
            ]
        });
    }
    getMuscleLoadCheckedValues() {
        var checkedArray = $('.checkbox-muscle-load:checked').map(function () {
            return parseInt($(this).val().toString());
        }).get();
        return checkedArray;
    }
    createCategoriesProductRequestDTO() {
        let muscleLoadRequestDTO = new CategoriesProductRequestDTO();
        muscleLoadRequestDTO.muscleLoadIds = this.getMuscleLoadCheckedValues();
        return muscleLoadRequestDTO;
    }
    applyCategories() {
        let categoriesProductRequestDTO = this.createCategoriesProductRequestDTO();
        $.ajax({
            type: 'POST',
            url: "/Product/GetListCategorized",
            data: { MuscleLoadIds: this.getMuscleLoadCheckedValues() },
            dataType: 'json',
            success: this.populateDataTable,
            error: function (e) {
                console.log("There was an error with your request...");
                console.log("error: " + JSON.stringify(e));
            }
        });
    }
    populateDataTable(dataToTable) {
        this.datatable = $("#productTable").DataTable();
        this.datatable.clear().draw();
        this.datatable.rows.add(dataToTable.data); // Add new data
        this.datatable.columns.adjust().draw(); // Redraw the DataTable
    }
}
class CategoriesProductRequestDTO {
}
let pageController = new ProductIndexPageController();
