function deleteCategory(id) {
    var url = '/Category/Delete/';

    $.ajax({
        url: url,
        type: 'DELETE',
        data: { id: id },
        success: function (result) {
            console.log('Film deleted successfully');
            window.location.reload()
        },
        error: function (xhr, status, error) {
            console.error('Error deleting category:', error);
        }
    });
}
