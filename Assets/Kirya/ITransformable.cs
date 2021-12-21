using UnityEngine;
public interface ITransformable
{
    public TypeObject Type { get; }
    public TypeTransformable TypeTransformable { get; }
    public bool HandleTransforming(TransfomrObject gameObject);
}