using UnityEngine;

public static class UnityHelpers {
    public static bool IsInMask(this LayerMask mask, int layer) {
        return (mask.value & (1 << layer)) == 0;
    }
}