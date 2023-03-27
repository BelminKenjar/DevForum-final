import { TestBed } from '@angular/core/testing';

import { PostReplyLikeService } from './post-reply-like.service';

describe('PostReplyLikeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PostReplyLikeService = TestBed.get(PostReplyLikeService);
    expect(service).toBeTruthy();
  });
});
