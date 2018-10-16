using Spine;
using Spine.Unity;
using Spine.Unity.Modules.AttachmentTools;
using UnityEngine;

namespace SpineTestLeak
{
    public class AutoEquip : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private Sprite _attachment;

        private void Start()
        {
            var slotIndex = _skeletonAnimation.skeleton.FindSlotIndex("sword");
            var templateSkin = _skeletonAnimation.SkeletonDataAsset.GetSkeletonData(false).FindSkin("default");
            var templateAttachment = templateSkin.GetAttachment(slotIndex, "sword");
            var attachment = templateAttachment.GetRemappedClone(_attachment,
                _skeletonAnimation.skeletonDataAsset.atlasAssets[0].materials[0], true);
            var skin = new Skin("EquipSkin");
            skin.Append(_skeletonAnimation.SkeletonDataAsset.GetSkeletonData(false).FindSkin("knight"));
            skin.AddAttachment(slotIndex, "sword", attachment);
            _skeletonAnimation.Skeleton.SetSkin(skin);
            _skeletonAnimation.Skeleton.SetSlotsToSetupPose();
        }
    }
}