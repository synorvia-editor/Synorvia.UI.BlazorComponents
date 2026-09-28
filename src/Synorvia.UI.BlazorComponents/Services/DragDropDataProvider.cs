using Synorvia.UI.DataModels.DragDrop;

namespace Synorvia.UI.BlazorComponents.Services
{
    public class DragDropDataProvider
    {
        private DragDropInformation _data;

        public void SetData(DragDropInformation data)
        {
            _data = data;
        }
        
        public DragDropInformation GetData()
        {
            return _data;   
        }
    }

}
