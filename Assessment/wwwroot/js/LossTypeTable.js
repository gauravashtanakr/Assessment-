$(document).ready(function () {

$('#table').on('processing.dt', function (e, settings, processing) {
    $('#table_processing').css('display', processing ? 'block' : 'none');
}).DataTable({
    processing: true,
    serverSide: true,
    searchable: true,
    scrollY: '50vh',
    pageLength: 100,
    ajax: {
        url: '../api/LossType',
        type: 'POST',
        dataSrc: 'data',
    },
    oLanguage: {
        sProcessing: "<div class='text-center' >\n\
                    <div class= 'spinner-border' role = 'status' >\n\
                    </div><div>Processing ...</div></div>"
    },
    "order": [[0, "desc"]],
    "columnDefs": [
        {
            'data': 'lossTypeId', 'name': 'LossTypeId', type: 'int', 'targets': [0]
        },
        {
            'data': 'lossTypeCode', 'name': 'LossTypeCode', type: 'int', 'targets': [1]
        },
        { 'data': 'lossTypeDescription', 'name': 'LossTypeDescription', 'targets': [2] }
    ],
    "scrollX": true,
    "scrollY": 357,
});

   
});