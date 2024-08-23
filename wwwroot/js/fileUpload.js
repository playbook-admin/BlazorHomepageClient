window.fileUpload = {
  initializeDropZone: function (dotNetHelper) {
    const dropZone = document.getElementById("dropZone");

    dropZone.addEventListener('dragenter', function (e) {
      e.preventDefault();
      dotNetHelper.invokeMethodAsync('HandleDragEnter');
    });

    dropZone.addEventListener('dragover', function (e) {
      e.preventDefault();
      dotNetHelper.invokeMethodAsync('HandleDragOver');
    });

    dropZone.addEventListener('dragleave', function (e) {
      e.preventDefault();
      dotNetHelper.invokeMethodAsync('HandleDragLeave');
    });

    dropZone.addEventListener('drop', function (e) {
      e.preventDefault();
      const files = e.dataTransfer.files;
      dotNetHelper.invokeMethodAsync('HandleDrop', Array.from(files).map(f => f.name));
    });
  }
};
