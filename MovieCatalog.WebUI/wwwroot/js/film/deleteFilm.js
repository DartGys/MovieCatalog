function deleteFilm (id)
{ 
    var url = '/Film/Delete/';

    $.ajax({
        url: url,
        type: 'DELETE',
        data: { id: id }, 
        success: function (result) {
            console.log('Film deleted successfully');
            $('#filmRow_' + id).remove();
        },
        error: function (xhr, status, error) {
            console.error('Error deleting film:', error);
        }
    });
}
