using UnityEngine;
using System.Collections;

public class TweenPosition2D : MonoBehaviour 
{
    public float MovementVelocity;
    public bool Loop = false;
    public Vector2[] TweenPositions;

    protected float _distanceTraveled;
    protected float _pointToPointLength;

    protected int _currentIndex;
    
    protected Vector2 _currentStart;
    protected Vector2 _currentEnd;
	protected Vector2 _direction;
    protected Vector2 _previousLocation;

	protected bool _playing = false;
    protected bool _finished = false;

	public void Start () 
    {
        if ( TweenPositions.Length > 0 )
        {
            Reset();
        }

        Play();
	}
	
	public void Update () 
    {
        if ( TweenPositions.Length > 0 && _playing && _currentIndex < TweenPositions.Length )
        {
            TweenUpdate();
            TransitionUpdate();
        }
	}

    protected void TweenUpdate()
    {
        this.rigidbody2D.velocity = _direction;

        Vector2 pos = this.transform.position;
        _distanceTraveled += Vector2.Distance( _previousLocation, pos );

        if ( _distanceTraveled > _pointToPointLength )
        {
            this.transform.position = _currentEnd;
            this.rigidbody2D.velocity = Vector2.zero;
        }

        _previousLocation = this.transform.position;
    }

    protected void TransitionUpdate()
    {
        if ( _currentEnd.x == this.transform.position.x && _currentEnd.y == this.transform.position.y )
        {
            if ( _currentIndex + 1 >= TweenPositions.Length )
            {
                _finished = true;
                _playing = false;

                if ( Loop ) PlayFromBegining();
                return;
            }

            SetNewDirection( TweenPositions[ _currentIndex ], TweenPositions[ _currentIndex + 1 ] );
            _currentIndex++;
        }
    }

    public void Reset()
    {
        _finished = false;
        _playing = false;
        SetNewDirection( TweenPositions[ 0 ], TweenPositions[ 1 ] );
        _currentIndex = 1;
        this.transform.position = _currentStart;
        _previousLocation = _currentStart;
    }

    public void Pause()
    {
        _playing = false;
    }

    public void Play()
    {
        _playing = true;
    }

    public void PlayFromBegining()
    {
        Reset();
        Play();
    }

    protected void SetNewDirection( Vector2 start, Vector2 end )
    {
        _distanceTraveled = 0.0f;
        _direction = ( end - start ).normalized * MovementVelocity;
        _currentStart = start;
        _currentEnd = end;
        _pointToPointLength = Vector2.Distance( _currentStart, _currentEnd );
    }
}
