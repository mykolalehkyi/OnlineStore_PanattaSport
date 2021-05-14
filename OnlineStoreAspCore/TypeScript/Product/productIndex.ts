class ProductIndexPageController {
    datatable;
    tableData;

    constructor() {
        $(document).ready(() => this.init());
    }

    init(): void {
        this.initDataTable();
    }

    initDataTable(): void {
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

    getMuscleLoadCheckedValues(): number[] {
        var checkedArray = $('.checkbox-muscle-load:checked').map(function () {
            return parseInt($(this).val().toString());
        }).get();
        return checkedArray;
    }

    createCategoriesProductRequestDTO():CategoriesProductRequestDTO {
        let muscleLoadRequestDTO = new CategoriesProductRequestDTO();
        muscleLoadRequestDTO.muscleLoadIds = this.getMuscleLoadCheckedValues();
        return muscleLoadRequestDTO;
    }

    applyCategories(): void {
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
        })
    }

    populateDataTable(dataToTable) {
        this.datatable = $("#productTable").DataTable();
        this.datatable.clear().draw();
        this.datatable.rows.add(dataToTable.data); // Add new data
        this.datatable.columns.adjust().draw(); // Redraw the DataTable
    }
}

class CategoriesProductRequestDTO {
    muscleLoadIds:number[];
}

let productIndexPageController = new ProductIndexPageController();
