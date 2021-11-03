using UnityEngine;
using System.Collections.Generic;

namespace Wrj
{
	[ExecuteInEditMode]
	public class LayoutGroupSunflower : WorldspaceLayoutGroup {

		public float radiusMax = 1f;
		public int maxRadiusAtCount = 100;
		private int _cachedMax;
		public AnimationCurve radiusGrowth;
		private float _cachedRadius;
		private List<Transform> _children;
		private int _cachedCount;
		
		private void OnValidate() 
		{
			if (Application.isPlaying) return;
			if (radiusMax != _cachedRadius || maxRadiusAtCount != _cachedMax)
			{
				_cachedRadius = radiusMax;
				_cachedMax = maxRadiusAtCount;
			}
			Refresh();
		}
		private float phi => (Mathf.Sqrt(5)+1)/2;           //golden ratio

		
		private List<Vector2> SunfowerDist(int n, int alpha = 2)
		{
			int b = Mathf.RoundToInt(alpha * Mathf.Sqrt(n));      // number of boundary points
			List<Vector2> plot = new List<Vector2>();
			for (int i = 0; i < n; i++)
			{
				float rad = Radius(i,n,b) * ScaledRadius(n);
				float theta = (2f * Mathf.PI) * (float)i / (Mathf.Pow(phi, 2f));
				plot.Add(new Vector2 (rad * Mathf.Cos(theta), rad * Mathf.Sin(theta)));
			}
			return plot;
		}
		private float ScaledRadius(int count)
		{
			return radiusGrowth.Evaluate(Mathf.InverseLerp(1f, maxRadiusAtCount, count)) * radiusMax;
		}
		private float Radius(int k, int n, int b)
		{
			if (k > (n - b)) return 1; //put on the boundary
			return Mathf.Sqrt(k-1/2)/Mathf.Sqrt(n-(b+1)/2); // apply square root
		}

		public override void Refresh()
		{
			List<Transform> children = new  List<Transform>();
			foreach (Transform child in transform)
			{
				if (child.gameObject.activeInHierarchy)
				{
					children.Add(child);
				}
			}
			if (_children != children)
			{
				_children = children;
			}

			Vector3 leftmostPos = transform.localPosition.With(x: -(radiusMax * (children.Count - 1)) * .5f);
			var distribution = SunfowerDist(_children.Count, 2);
			for (int i = 0; i < distribution.Count; i++)
			{
				children[i].localPosition = distribution[i];
			}
		}
	}
}


// function sunflower(n, alpha)   %  example: n=500, alpha=2
//     clf
//     hold on
//     b = round(alpha*sqrt(n));      % number of boundary points
//     phi = (sqrt(5)+1)/2;           % golden ratio
//     for k=1:n
//         r = radius(k,n,b);
//         theta = 2*pi*k/phi^2;
//         plot(r*cos(theta), r*sin(theta), 'r*');
//     end
// end

// function r = radius(k,n,b)
//     if k>n-b
//         r = 1;            % put on the boundary
//     else
//         r = sqrt(k-1/2)/sqrt(n-(b+1)/2);     % apply square root
//     end
// end
