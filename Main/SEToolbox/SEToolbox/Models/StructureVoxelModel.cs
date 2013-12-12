﻿namespace SEToolbox.Models
{
    using Sandbox.CommonLib.ObjectBuilders;
    using Sandbox.CommonLib.ObjectBuilders.Voxels;
    using SEToolbox.Interop;
    using System;
    using System.IO;
    using System.Xml.Serialization;

    [Serializable]
    public class StructureVoxelModel : StructureBaseModel
    {
        #region ctor

        public StructureVoxelModel(MyObjectBuilder_EntityBase entityBase)
            : base(entityBase)
        {
        }

        #endregion

        #region Properties

        [XmlIgnore]
        public MyObjectBuilder_VoxelMap VoxelMap
        {
            get
            {
                return this.EntityBase as MyObjectBuilder_VoxelMap;
            }
        }

        [XmlIgnore]
        public string Filename
        {
            get
            {
                return this.VoxelMap.Filename;
            }

            set
            {
                if (value != this.VoxelMap.Filename)
                {
                    this.VoxelMap.Filename = value;
                    this.RaisePropertyChanged(() => Filename);
                }
            }
        }

        #endregion

        #region methods

        public override void UpdateFromEntityBase()
        {
            this.ClassType = ClassType.Voxel;
            this.Description = Path.GetFileNameWithoutExtension(this.VoxelMap.Filename);
        }

        #endregion
    }
}
